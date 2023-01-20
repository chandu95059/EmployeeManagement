Imports System.Data.OleDb

Public Class EmpFrm
    '1.This is for server connection 
    Dim mycon As New OleDbConnection("Provider=SQLOLEDB.1;Password=123;Persist Security Info=True;User ID=sa;Initial Catalog=Emanagement;Data Source=chandu")

    '2.Select Statements 
    Dim myadapter As New OleDbDataAdapter

    '3. Temp Data Storage
    Dim mydset As New DataSet

    '4.insert update delete 
    Dim mycmd As New OleDbCommand

    '5.max/min/count/avg/sum 
    Dim myreader As OleDbDataReader

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub EmpFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Sub getdata()
        myadapter = New OleDbDataAdapter("select * from Employee", mycon)
        mydset = New DataSet
        myadapter.Fill(mydset, "Employee")
        DataGrid1.DataSource = mydset
        DataGrid1.SetDataBinding(mydset, "Employee")
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        getdata()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mycon.Open()
        mycmd.CommandText = "insert into Employee values(" & TextBox1.Text & ",'" & TextBox2.Text & "','" & DateTimePicker1.Text & "'," & TextBox3.Text & ",'" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "'," & TextBox4.Text & ",'" & ComboBox4.Text & "','" & ListBox1.Text & "')"
        mycmd.Connection = mycon
        mycmd.ExecuteNonQuery()
        mycon.Close()
        MsgBox("Employee Added Succesfully")
        getdata()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mycon.Open()

        mycon.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        myadapter = New OleDbDataAdapter("select * from Employee where ENo = " & TextBox5.Text & "", mycon)
        mydset = New DataSet
        myadapter.Fill(mydset, "Employee")
        Dim dr As New Object
        dr = mydset.Tables("Employee").Select()
        If dr.length = 0 Then
            MsgBox("Employee Does not Exists")
        Else
            TextBox1.Text = dr(0).item(0)
            TextBox2.Text = dr(0).item(1)
            DateTimePicker1.Text = dr(0).item(2)
            TextBox3.Text = dr(0).item(3)
            ComboBox1.Text = dr(0).item(4)
            ComboBox2.Text = dr(0).item(5)
            ComboBox3.Text = dr(0).item(6)
            TextBox4.Text = dr(0).item(7)
            ComboBox4.Text = dr(0).item(8)
            ListBox1.Text = dr(0).item(9)
        End If
        getdata()
    End Sub
End Class