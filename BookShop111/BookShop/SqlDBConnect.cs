using System.Linq;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;
//以下是反射需要用到的命名空间
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;

public class SqlDBConnect
{
    private string connectionString = "";
    private SqlConnection conn = null;

    #region  //构造函数
    public SqlDBConnect()
    {
        //string connectionString = "data source=222.73.41.20;Initial Catalog=Zebra;User ID=ncuser;Password=netcansoft.com@lanny2013;";
        //this.connectionString = ConfigurationManager.AppSettings["DBContext"].ToString();
        this.connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BookShop"].ToString();
        this.conn = new SqlConnection(connectionString);
    }
    #endregion

    #region //打开连接
    public void OpenDb()
    {
        if (conn.State != ConnectionState.Open)
        {
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
    #endregion

    #region //关闭连接
    public void CloseDb()
    {
        if (!object.Equals(conn, null) && (conn.State != ConnectionState.Closed))
        {
            conn.Close();
        }
    }
    #endregion

    #region //释放连接
    public void Dispose()
    {
        if (conn != null)
        {
            conn.Dispose();
            conn = null;
        }
    }
    #endregion

    #region  //执行单条SQL(插入、更新、删除)
    /// <summary>
    /// 执行单条SQL(插入、更新、删除)
    /// </summary>
    /// <param name="sql_"></param>
    public void ExecuteNonQuery(string sql_)
    {
        try
        {
            OpenDb();
            SqlCommand cm = new SqlCommand(sql_, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            cm = null;
            CloseDb();
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + "  " + sql_);
        }
    }

    public bool ExecuteNonQueryBool(string sql_)
    {
        try
        {
            OpenDb();
            SqlCommand cm = new SqlCommand(sql_, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            cm = null;
            CloseDb();
            return true;
        }
        catch (Exception e)
        {
            return false;
            throw new Exception(e.ToString() + "  " + sql_);            
        }
    }
    #endregion

    #region  //执行SQL返回首行首列的值
    /// <summary>
    /// 执行SQL返回首行首列的值,不存在返回""
    /// </summary>
    public string GetSingleVal(string sql_)
    {
        string RetStr = null;
        try
        {
            OpenDb();
            SqlCommand cm = new SqlCommand(sql_, conn);
            RetStr = cm.ExecuteScalar() == null ? "" : cm.ExecuteScalar().ToString();
            cm.Dispose();
            cm = null;
            CloseDb();
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + ", " + sql_);
        }

        return RetStr;
    }
    #endregion

    #region  //判断是否存在对应的数据
    /// <summary>
    /// 根据SQL判断是否存在对应的数据
    /// </summary>
    public bool YNExistData(string sql_)
    {
        bool ynExist = false;
        try
        {
            DataTable dt = GetDataTable(sql_);
            if (dt != null && dt.Rows.Count > 0)
                ynExist = true;
        }
        catch (Exception e)
        {
            ynExist = false;
            throw new Exception(e.ToString() + ", " + sql_);
        }

        return ynExist;
    }
    #endregion

    #region  //执行SQL返回DataSet数据集
    /// <summary>
    /// 执行SQL返回DataSet数据集
    /// </summary>
    /// <param name="sql_"></param>
    /// <returns></returns>
    public DataSet GetDataSet(string sql_)
    {
        if (sql_ == "")
            return null;
        DataSet ds = null;
        try
        {
            OpenDb();
            SqlDataAdapter myad = new SqlDataAdapter(sql_, conn);
            ds = new DataSet();
            myad.Fill(ds);//用数据适配器填充数据集
            myad.Dispose();
            myad = null;
            CloseDb();

            if (ds.Tables.Count <= 0)
                return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + "  " + sql_);
        }
        return ds;
    }
    #endregion

    #region  //执行SQL返回DataTable数据集
    /// <summary>
    /// 执行SQL返回DataTable数据集
    /// </summary>
    /// <param name="sql_"></param>
    /// <returns></returns>
    public DataTable GetDataTable(string sql_)
    {
        if (sql_ == "")
            return null;
        DataTable dt = null;
        DataSet ds = null;
        try
        {
            OpenDb();
            SqlDataAdapter myad = new SqlDataAdapter(sql_, conn);
            ds = new DataSet();
            myad.Fill(ds);//用数据适配器填充数据集
            myad.Dispose();
            myad = null;
            CloseDb();

            if (ds.Tables.Count <= 0)
                return null;
            dt = ds.Tables[0];
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + "  " + sql_);
        }
        return dt;
    }
    #endregion

    #region //使用事务执行多条SQL(插入、更新、删除)
    /// <summary>
    /// 使用事务执行多条SQL(插入、更新、删除)
    /// </summary>
    /// <param name="sqls"></param>
    public bool ExecTansaction(List<string> sqls)
    {
        if (sqls.Count == 0) return false;

        OpenDb();

        // 启动一个事务。 
        SqlTransaction myTran = conn.BeginTransaction();
        // 为事务创建一个命令
        SqlCommand myCom = new SqlCommand();
        myCom.Connection = conn;
        myCom.Transaction = myTran;
        try
        {
            foreach (string sql in sqls)
            {
                myCom.CommandText = sql;
                myCom.ExecuteNonQuery();
            }
            myTran.Commit();//提交事务
            return true;
        }
        catch (Exception Ex)
        {
            myTran.Rollback();

            //返回异常的错误信息 
            //MessageBox.Show("提交数据失败!\n" + ex.Message.ToString(), "异常信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            throw new Exception("提交数据失败!\n" + Ex.Message.ToString());
            return false;
        }
        finally
        {
            conn.Close();
        }
    }
    #endregion

    #region //获得数据库服务器当前时间
    /// <summary>
    /// 获得数据库服务器当前时间
    /// </summary>
    /// <returns></returns>
    public DateTime Get_DbServerTime()
    {
        SqlDataReader rs = null;
        DateTime dt = new DateTime();
        try
        {
            CloseDb();
            OpenDb();
            SqlCommand cm = new SqlCommand("select getdate() ", conn);
            rs = cm.ExecuteReader(CommandBehavior.CloseConnection);
            cm.Dispose();
            cm = null;
            //Close();
            if (rs.Read())
            { dt = DateTime.Parse(rs[0].ToString()); }
                
            CloseDb();
        }
        catch
        {
            throw new Exception("取服务器时间出错！");
        }
        return dt;
    }
    #endregion

    #region  //执行对单个Entity的更新
    /// <summary>
    /// 执行对单个Entity的更新
    /// </summary>
    /// <param name="baseEntity"></param>
    public void ExecuteObjectUpdate(BaseEntity baseEntity)
    {
        ExecuteObjectUpdate(baseEntity, "");
    }
    #endregion

    #region  //执行对单个Entity的更新(这个可以添加额外的约束条件)
    /// <summary>
    /// 执行对单个Entity的更新
    /// </summary>
    /// <param name="baseEntity">由控制器组装而来的实体</param>
    /// <param name="otherConditions">其他约束条件用(and开头,例如:"and name='王斐'"</param>
    public void ExecuteObjectUpdate(BaseEntity baseEntity, string otherConditions)
    {
        string sql_ = "";//values 之前
        try
        {
            Type type = baseEntity.GetType();
            IList<CustomAttributeData> tableAttribute = type.GetCustomAttributesData();//该方法是根据Type属性找到的
            string tableName = "";//表名
            tableName = (String)tableAttribute[0].ConstructorArguments[0].Value;//解刨Type属性中偶然发现

            string operation = "update";//执行操作方法,此处可以考虑将操作类型operation由调用者确定
            PropertyInfo[] propertyList = type.GetProperties();//返回PropertyInfo类型，用于取得该类的属性的信息

            //生成SQL语句
            string propertyName = "";//属性名
            string propertyValue = "";//属性值

            sql_ = operation + " " + tableName + " set ";

            int updateCount = 0;//用于计数更新

            for (int i = 1; i < propertyList.Length; i++)
            //这里考虑并没有写死跟添加一样,也从0开始,有一段时间考虑想从i=1开始,
            //但是存在部分情况主键可以改变的情况,因此,这里会默认的将首字段进行拼接,
            //会出现update tableName set PKName=value.... where  PKName=value;的情况
            //个人认为这并不影响


            //2015年5月28日02:14:26
            //由于部分主键是自增的,如果默认主键参与跟新,则会因为自增字段不能update而报错
            //但是没有找到合适方法
            //这里还是从第2个开始判断
            {
                //propertyList.Add("");
                propertyName = propertyList[i].Name;
                propertyValue = GetObjectPropertyValue(type, baseEntity, propertyName);//获取属性值
                if (propertyValue != null)
                {
                    if (updateCount != 0)//判断是否是第一个更新的字段如果是则不添加逗号
                    {
                        sql_ += " , ";
                    }
                    sql_ += "[" + propertyName + "]"+"= N'{0}'";
                    sql_ = string.Format(sql_, propertyValue);
                    updateCount++;
                }

            }
            string PKPropertyName = propertyList[0].Name;//此处还在考虑 是否需要解析一下 ,可以改为支持两个主键或者以上
            string PKPropertyValue = GetObjectPropertyValue(type, baseEntity, PKPropertyName);

            sql_ = sql_ + " where " + PKPropertyName + "=N'{0}'" + " " + otherConditions;//此处添加而外约束条件跟主键
            sql_ = String.Format(sql_, PKPropertyValue);

            OpenDb();
            SqlCommand cm = new SqlCommand(sql_, conn);
            cm.ExecuteNonQuery();
            cm.Dispose();
            cm = null;
            CloseDb();
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + "  " + sql_);
        }

    }
    #endregion

    #region  //执行对单个Entity的插入
    /// <summary>
    /// 执行对单个Entity的插入（多表操作，表中含有自增字段慎用） 返回值是Entity的第一个属性
    /// </summary>
    /// <param name="sql_"></param>
    public string ExecuteObjectInput(BaseEntity baseEntity, string tableName)
    {
        string sql_ = "";//values 之前
        try
        {
            Type type = baseEntity.GetType();//得到对象类型
            IList<CustomAttributeData> tableAttribute = type.GetCustomAttributesData();//该方法是根据Type属性找到的
            //string tableName = "";//表名
            //tableName = (String)tableAttribute[0].ConstructorArguments[0].Value;//解刨Type属性中偶然发现
            string operation = "insert into ";//执行操作方法
            PropertyInfo[] propertyList = type.GetProperties();//返回PropertyInfo类型，用于取得该类的属性的信息

            //生成SQL语句
            string values = "";//values( 之后 最后一起拼装起来
            string propertyName = "";//属性名
            string propertyValue = "";//属性值

            sql_ = operation + " " + tableName + " ( ";

            int inputCount = 0;//用于计数新增
            for (int i = 0; i < propertyList.Length; i++)//这个从Entity第一个属性开始就解析,主要因为添加时候只要主属性不是自增的就需要填写
            {
                //propertyList.Add("");
                propertyName = propertyList[i].Name;
                propertyValue = GetObjectPropertyValue(type, baseEntity, propertyName);//获取属性值
                if (propertyValue != null)
                {
                    if (inputCount != 0)
                    {
                        sql_ += " , ";
                        values += " , ";
                    }
                    sql_ += "["+propertyName+"]";

                    values += " N'{0}' ";
                    values = string.Format(values, propertyValue);
                    inputCount++;
                }

            }
            sql_ = sql_ + ") output inserted.{0} values(" + values + ")";

            sql_ = string.Format(sql_, propertyList[0].Name);
                 
            OpenDb();
            SqlCommand cm = new SqlCommand(sql_, conn);
            //ulong returnId = cm.ExecuteNonQuery();
            string returnId =cm.ExecuteScalar().ToString();
            cm.Dispose();
            cm = null;
            CloseDb();
            return returnId;
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + "  " + sql_);
        }

    }
    #endregion

    #region  //返回对单个Entity的插入的SQL语句
    /// <summary>
    /// 返回对单个Entity的插入的SQL语句（多表操作，表中含有自增字段慎用） 返回值是Entity的第一个属性
    /// </summary>
    /// <param name="sql_"></param>
    public string GetObjectInputSql(BaseEntity baseEntity, string tableName)
    {
        string sql_ = "";//values 之前
        try
        {
            Type type = baseEntity.GetType();//得到对象类型
            IList<CustomAttributeData> tableAttribute = type.GetCustomAttributesData();//该方法是根据Type属性找到的
            //string tableName = "";//表名
            //tableName = (String)tableAttribute[0].ConstructorArguments[0].Value;//解刨Type属性中偶然发现
            string operation = "insert into ";//执行操作方法
            PropertyInfo[] propertyList = type.GetProperties();//返回PropertyInfo类型，用于取得该类的属性的信息

            //生成SQL语句
            string values = "";//values( 之后 最后一起拼装起来
            string propertyName = "";//属性名
            string propertyValue = "";//属性值

            sql_ = operation + " " + tableName + " ( ";

            int inputCount = 0;//用于计数新增
            for (int i = 0; i < propertyList.Length; i++)//这个从Entity第一个属性开始就解析,主要因为添加时候只要主属性不是自增的就需要填写
            {
                //propertyList.Add("");
                propertyName = propertyList[i].Name;
                propertyValue = GetObjectPropertyValue(type, baseEntity, propertyName);//获取属性值
                if (propertyValue != null)
                {
                    if (inputCount != 0)
                    {
                        sql_ += " , ";
                        values += " , ";
                    }
                    sql_ += "[" + propertyName + "]";

                    values += " N'{0}' ";
                    values = string.Format(values, propertyValue);
                    inputCount++;
                }

            }
            //sql_ = sql_ + ") output inserted.{0} values(" + values + ")";
            //sql_ = string.Format(sql_, propertyList[0].Name);

            sql_ = sql_ + ") values(" + values + ")"; //sql server2000不支持output

            return sql_;
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + "  " + sql_);
            return "";
        }

    }
    #endregion

    #region  //C#利用反射获取对象属性值
    /// <summary>
    /// C#利用反射获取对象属性值
    /// </summary>
    /// <param name="type"></param>
    /// <param name="baseEntity"></param>
    /// <param name="propertyname">需要更改的值</param>
    /// <returns></returns>
    public static string GetObjectPropertyValue(Type type, BaseEntity baseEntity, string propertyname)
    {

        PropertyInfo property = type.GetProperty(propertyname);//根据变量名得到变量对象

        //if (property == null) return null;//BaseEntity.cs属性名与BaseModel.cs中属性名不相同时,并不进行编辑

        object o = property.GetValue(baseEntity, null);//从实体中获取具体值 重要

        if (o == null) return null;

        return o.ToString();
    }
    #endregion

    #region  //将sr_readStr数组存入数据库image类型的字段中
    /// <summary>
    /// 将sr_readStr数组存入数据库image类型的字段中
    /// </summary>
    /// <param name="sql_"></param>
    public void ExecuteNonQuery_Byte(string sql_, byte[] sr_readStr)
    {
        try
        {
            OpenDb();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql_;
            SqlParameter par = new SqlParameter("@imgfile", SqlDbType.Image);
            par.Value = sr_readStr;
            cmd.Parameters.Add(par);
            cmd.ExecuteNonQuery();
            CloseDb();
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + "  " + sql_);
        }
    }
    #endregion

    #region //执行SQL返回DataReader数据集
    public SqlDataReader getDataReader(String sql_)
    {
        if (sql_ == "")
            return null;
        SqlDataReader returnReader = null;
        try
        {
            OpenDb();
            SqlCommand command=new SqlCommand(sql_,conn);
            returnReader = command.ExecuteReader();
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString() + "  " + sql_);
        }
        return returnReader;
    }
    #endregion


    #region 执行带参数的SQL语句
    /// <summary>
    /// 执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="sqlString">SQL语句</param>
    /// <param name="cmdParms"></param>
    /// <returns>影响的记录数</returns>
    public int ExecuteNonQuery(string sqlString, params SqlParameter[] cmdParms)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand())
            {
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                int rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return rows;
            }
        }
    }
    /// <summary>
    /// 执行多条SQL语句，实现数据库事务。
    /// </summary>
    /// <param name="sqlStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
    public void ExecuteSqlTran(Hashtable sqlStringList)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                var cmd = new SqlCommand();
                try
                {
                    //循环
                    foreach (DictionaryEntry myDe in sqlStringList)
                    {
                        string cmdText = myDe.Key.ToString();
                        var cmdParms = (SqlParameter[])myDe.Value;
                        PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }
        
    /// <summary>
    /// 执行多条SQL语句，实现数据库事务。
    /// </summary>
    /// <param name="sqlStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
    public void ExecuteSqlTranWithIndentity(Hashtable sqlStringList)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                var cmd = new SqlCommand();
                try
                {
                    int indentity = 0;
                    //循环
                    foreach (DictionaryEntry myDe in sqlStringList)
                    {
                        string cmdText = myDe.Key.ToString();
                        var cmdParms = (SqlParameter[])myDe.Value;
                        foreach (var q in cmdParms)
                        {
                            if (q.Direction == ParameterDirection.InputOutput)
                            {
                                q.Value = indentity;
                            }
                        }
                        PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        cmd.ExecuteNonQuery();
                        foreach (SqlParameter q in cmdParms)
                        {
                            if (q.Direction == ParameterDirection.Output)
                            {
                                indentity = Convert.ToInt32(q.Value);
                            }
                        }
                        cmd.Parameters.Clear();
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="sqlString">计算查询结果语句</param>
    /// <param name="cmdParms"></param>
    /// <returns>查询结果（object）</returns>
    public object GetSingleVal(string sqlString, params SqlParameter[] cmdParms)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand())
            {
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                object obj = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
                {
                    return null;
                }
                return obj;
            }
        }
    }

    /// <summary>
    /// 执行查询语句，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
    /// </summary>
    /// <param name="sqlString"></param>
    /// <param name="cmdParms"></param>
    /// <returns>SqlDataReader</returns>
    public SqlDataReader ExecuteReader(string sqlString, params SqlParameter[] cmdParms)
    {
        var connection = new SqlConnection(connectionString);
        var cmd = new SqlCommand();
        PrepareCommand(cmd, connection, null, sqlString, cmdParms);
        SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        cmd.Parameters.Clear();
        return myReader;
        
    }
    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="sqlString">查询语句</param>
    /// <param name="cmdParms"></param>
    /// <returns>DataSet</returns>
    public DataSet GetDataSet(string sqlString, params SqlParameter[] cmdParms)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, sqlString, cmdParms);
            using (var da = new SqlDataAdapter(cmd))
            {
                var ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }
    }
    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="sqlString">查询语句</param>
    /// <param name="cmdParms"></param>
    /// <returns>DataSet</returns>
    public DataTable GetDataTable(string sqlString, params SqlParameter[] cmdParms)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, sqlString, cmdParms);
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                var ds = new DataSet();
                try
                {
                    da.Fill(ds, "ds");
                    if (ds.Tables.Count <= 0)
                        return null;
                    dt = ds.Tables[0];

                    cmd.Parameters.Clear();
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;
            }
        }
    }

    private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, IEnumerable<SqlParameter> cmdParms)
    {
        if (conn.State != ConnectionState.Open)
            conn.Open();
        cmd.Connection = conn;
        cmd.CommandText = cmdText;
        if (trans != null)
            cmd.Transaction = trans;
        cmd.CommandType = CommandType.Text;//cmdType;
        if (cmdParms != null)
        {


            foreach (var parameter in cmdParms)
            {
                if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                    (parameter.Value == null))
                {
                    parameter.Value = DBNull.Value;
                }
                cmd.Parameters.Add(parameter);
            }
        }
    }

    #endregion
}


public class BaseEntity
{ 
}

