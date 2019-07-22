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

    Sub InsertTest2_1000()
        Console.WriteLine("InsertTest s --- ")

        Using conn As New MySqlConnection("Database=test;Data Source=localhost;User Id=root;Password=; sqlservermode=True;")
            conn.Open()
            Dim cmd As New MySqlCommand()
            cmd.Connection = conn

            Dim commandValue As String = "VALUES"

            For i As Integer = 0 To 1000
                Dim type As Integer = i Mod 3
                If i > 0 Then
                    commandValue += ", ('" & i.ToString() & "', 'ro', " & type.ToString() & ")"
                Else
                    commandValue += "('" & i.ToString() & "', 'ro', " & type.ToString() & ")"
                End If

            Next
            cmd.CommandText = "INSERT INTO `testtable2` (`id`, `name`, `type`) " & commandValue
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
        Console.WriteLine("InsertTest e --- ")

    End Sub


    Sub UpdateTest()
        Console.WriteLine("UpdateTest s --- ")

        Using conn As New MySqlConnection("Database=test;Data Source=localhost;User Id=root;Password=; sqlservermode=True;")
            conn.Open()
            Dim cmd As New MySqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "Update `testtable1` SET `name` = 'taro' WHERE id = '1';"
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
        Console.WriteLine("UpdateTest e --- ")
    End Sub
    Sub UpdateTest2()
        Console.WriteLine("UpdateTest s --- ")

        Using conn As New MySqlConnection("Database=test;Data Source=localhost;User Id=root;Password=; sqlservermode=True;")
            conn.Open()
            Dim cmd As New MySqlCommand()
            cmd.Connection = conn
            cmd.CommandText = "Update `testtable1` SET `name` = 'Balbatos' WHERE id = '1';"
            cmd.CommandText &= "Update `testtable1` SET `name` = 'Roronoa' WHERE id = '2';"
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
        Console.WriteLine("UpdateTest e --- ")
    End Sub


    Sub UpdateTest1000()
        Console.WriteLine("UpdateTest s --- ")

        Using conn As New MySqlConnection("Database=test;Data Source=localhost;User Id=root;Password=; sqlservermode=True;")
            conn.Open()

            Dim cmd As New MySqlCommand()
            cmd.Connection = conn
            Dim sqr_cmd As String = "Update `testtable1` SET `name` = ELT(FIELD(id,"
            Dim sqr_ids As String = ""
            Dim sqr_names As String = ""


            For i As Integer = 0 To 1000
                If i > 0 Then
                    sqr_ids &= "," & i.ToString()
                    sqr_names &= "," & Chr(34) & "n" & i.ToString() & Chr(34)
                Else
                    sqr_ids &= i.ToString()
                    sqr_names &= Chr(34) & "n" & i.ToString() & Chr(34)
                End If

            Next

            sqr_cmd &= sqr_ids & ")," & sqr_names & ") WHERE id IN (" & sqr_ids & ")"
            cmd.CommandText = sqr_cmd

            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
        Console.WriteLine("UpdateTest e --- ")
    End Sub

    Sub UpdateTest1000_t2()
        Console.WriteLine("UpdateTest s --- ")

        Using conn As New MySqlConnection("Database=test;Data Source=localhost;User Id=root;Password=; sqlservermode=True;")
            conn.Open()

            Dim cmd As New MySqlCommand()
            cmd.Connection = conn
            Dim sqr_cmd As String = "Update `testtable1` SET `name` = ELT(FIELD(id,"
            Dim sqr_ids As String = ""
            Dim sqr_names As String = ""


            For i As Integer = 0 To 1000
                If i > 0 Then
                    sqr_ids &= "," & i.ToString()
                    sqr_names &= "," & Chr(34) & "n" & i.ToString() & Chr(34)
                Else
                    sqr_ids &= i.ToString()
                    sqr_names &= Chr(34) & "n" & i.ToString() & Chr(34)
                End If

            Next

            sqr_cmd &= sqr_ids & ")," & sqr_names & ") WHERE id IN (" & sqr_ids & ")"
            cmd.CommandText = sqr_cmd

            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
        Console.WriteLine("UpdateTest e --- ")
    End Sub

    Sub Main()
        'InsertTest()
        'InsertTest1000()
        'InsertTest2_1000()
        'UpdateTest2()
        'UpdateTest()
        'UpdateTest1000()
        UpdateTest1000_t2()
    End Sub

End Module
