Imports Telerik.Web.UI
Imports System.Data

Partial Class Index
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        System.Console.WriteLine("PAGE LOAD!?")
        Dim dbconn = New OleDb.OleDbConnection("Server=.\SQLEXPRESS;Database=MookstrDB;Provider=SQLOLEDB;Trusted_Connection=Yes;")
        dbconn.Open()
        Dim dbSchema As DataTable = dbconn.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, Nothing)
        Dim firstSheetName As String = dbSchema.Rows(0)("TABLE_NAME").ToString()
        System.Console.WriteLine(firstSheetName)
        Dim SQL = "Select * from [POS_Data]"
        Dim dbcomm = New OleDb.OleDbCommand(SQL, dbconn)
        Dim dbread = dbcomm.ExecuteReader()
        store_info.DataSource = dbread
        store_info.DataBind()
        dbread.Close()
        dbconn.Close()
    End Sub

End Class
