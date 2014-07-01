Imports Telerik.Web.UI
Imports System.Data

Partial Class Index
    Inherits System.Web.UI.Page

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        System.Console.WriteLine("PAGE LOAD!?")
        Dim dbconn = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=~/raw_data.xlsx;Extended Properties=""Excel 8.0;HDR=YES;""")
        dbconn.Open()
        Dim SQL = "Select ""Store Name"" as ""Store"", ""Store Nbr"" as ""SNMBR"", ""Whse Name"" as ""WHS"", ""Whse Nbr"" as ""WHSNMBR"" from [Sheet1$] GROUP BY WHSNMBR"
        Dim dbcomm = New OleDb.OleDbCommand(SQL, dbconn)
        Dim dbread = dbcomm.ExecuteReader()
        store_info.DataSource = dbread
        store_info.DataBind()
        dbread.Close()
        dbconn.Close()
    End Sub

End Class
