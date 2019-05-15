Imports MySql.Data.MySqlClient

Module Module1


    Sub SelectOne()
        Using conn As New MySqlConnection("Database=test;Data Source=localhost;User Id=root;Password=; sqlservermode=True;")
            conn.Open()

            Console.WriteLine("connect")
            Dim da As New MySqlDataAdapter("select * From abtb", conn)
            Dim ds As New DataSet
            da.Fill(ds)


            Dim dt As DataTable = ds.Tables(0)
            Dim columns As DataColumnCollection = dt.Columns
            Dim rows As DataRowCollection = dt.Rows
            Console.WriteLine("{0}" & vbTab & "{1}", columns(0).ColumnName, columns(1).ColumnName)
            Console.WriteLine("-----------------------------")

            For r As Integer = 0 To rows.Count - 1

                For c As Integer = 0 To columns.Count - 1
                    Console.Write(rows(r)(c) & vbTab)
                Next

                Console.WriteLine()
            Next

            'Console.Write(ds.ToString())
            conn.Close()
        End Using

    End Sub

    Sub InsertTest()
        Console.WriteLine("InsertTest s --- ")

        Using conn As New MySqlConnection("Database=test;Data Source=localhost;User Id=root;Password=; sqlservermode=True;")
            conn.Open()
            Dim cmd As New MySqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO `testtable1` (`name`) VALUES ('ro');"
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
        Console.WriteLine("InsertTest e --- ")
    End Sub

    Sub InsertTest1000()
        Console.WriteLine("InsertTest s --- ")

        Using conn As New MySqlConnection("Database=test;Data Source=localhost;User Id=root;Password=; sqlservermode=True;")
            conn.Open()
            Dim cmd As New MySqlCommand()
            cmd.Connection = conn

            Dim commandValue As String = "VALUES"

            For i As Integer = 0 To 1000
                If i > 0 Then
                    commandValue += ", ('" & i.ToString() & "', 'ro')"
                Else
                    commandValue += "('" & i.ToString() & "', 'ro')"
                End If

            Next
            cmd.CommandText = "INSERT INTO `testtable1` (`id`, `name`) " & commandValue
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
        Console.WriteLine("InsertTest e --- ")
    End Sub

    Sub Main()
        'InsertTest()
        InsertTest1000()
    End Sub

End Module
