'Program Info
'-----------------------------------------------------------------------------
'Program: Instructor & Classroom
'Date: December 5th 2018
'Author: Dalyce Hill
'Operation: This program will allow the user to enter an instructor and 
'           classroom then after pressing the Add button, the program will check
'           to see if both values are entered and valid then add it to an array.
'           The user also has the option of searching for a instructor or a
'           classroom by using two radio buttons and a textbox. Values are 
'           validated here as well.
'-----------------------------------------------------------------------------
'Change Log
'-----------------------------------------------------------------------------
'Date                   Programmer                  Change
'-----------------------------------------------------------------------------
'12/05/2018             Dalyce Hill                 Initial Version

Public Class INSTRUCTOR
    'Arrays
    Dim arr_instructors(9) As String
    Dim arr_classroom(9) As String

    'Add button
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        'Variable declarations
        Dim index_instructors As Integer
        Dim index_classroom As Integer

        'Validates instructor name; message box displayed if not valid
        If txt_instructor.Text = Nothing Or IsNumeric(txt_instructor.Text) Then
            MsgBox("Please enter a valid instructor name")
            txt_instructor.Focus()
            txt_instructor.Clear()

            'Validates classroom; message box displayed if not valid
        ElseIf txt_classroom.Text = Nothing Or IsNumeric(txt_classroom.Text) Then
            MsgBox("Please enter a valid classroom")
            txt_classroom.Focus()
            txt_classroom.Clear()

        Else

            'For...Next loops through the instructors array
            For index_instructors = 0 To arr_instructors.Count - 1

                'Current index must not equal the entered name to continue
                If Not txt_instructor.Text = arr_instructors(index_instructors) Then

                    'Current index must be blank to continue
                    If arr_instructors(index_instructors) = Nothing Then

                        'For...Next loops through the classroom array
                        For index_classroom = 0 To arr_classroom.Count - 1

                            'Current index must not equal the entered classroom to continue
                            If Not txt_classroom.Text = arr_classroom(index_classroom) Then

                                'Current index must be blank to continue
                                If arr_classroom(index_classroom) = Nothing Then

                                    'Adds the entered classroom & instructor to their respective arrays
                                    arr_classroom(index_classroom) = txt_classroom.Text
                                    arr_instructors(index_instructors) = txt_instructor.Text

                                    Exit For
                                End If

                                'If the classroom entered is already in the array, message box is displayed
                            Else

                                MsgBox("That classroom has already been entered")
                                txt_classroom.Focus()
                                txt_classroom.Clear()

                                Exit For
                            End If
                        Next
                        Exit For
                    End If

                    'If the instructor entered is already in the array, message box is displayed  
                Else

                    'Sets the classroom index to the current instructor index 
                    index_classroom = index_instructors

                    MsgBox($"That instructor has already been entered with classroom {arr_classroom(index_classroom)}")
                    txt_instructor.Focus()
                    txt_instructor.Clear()

                    Exit For
                End If
            Next
        End If
    End Sub

    'Search button
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        'Variable declarations
        Dim index_searchInstruct As Integer
        Dim index_searchClassroom As Integer

        'Validates textbox; message box if not valid
        If txt_search.Text = Nothing Then
            MsgBox("Please enter a search term")

            'Validates radio buttons; message box if not valid
        ElseIf rdbtn_SearchClassroom.Checked = False And rdbtn_SearchInstruct.Checked = False Then
            MsgBox("Please select instructor or classroom")

            'If Search Instructor radio button is checked, continue
        ElseIf rdbtn_SearchInstruct.Checked = True Then

            'For...Next loops through the instructors array
            For index_searchInstruct = 0 To arr_instructors.Count - 1

                'If the instructor entered is found in the array, it sets the classroom index to the 
                'current instructor index and displays a message box
                If txt_search.Text = arr_instructors(index_searchInstruct) Then

                    index_searchClassroom = index_searchInstruct
                    MsgBox($"Instructor {txt_search.Text} is in classroom {arr_classroom(index_searchClassroom)}")
                    Exit For

                ElseIf arr_instructors(index_searchInstruct) = Nothing Then

                    'If instructor is not in the array, message box is displayed
                    MsgBox("Instructor not found")

                    Exit For
                End If
            Next
        Else

            'For...Next loops through the classrooom array
            For index_searchClassroom = 0 To arr_classroom.Count - 1

                'If the classroom entered is found in the array, it sets the instructor index to the 
                'current classroom index and displays a message box
                If txt_search.Text = arr_classroom(index_searchClassroom) Then

                    index_searchInstruct = index_searchClassroom
                    MsgBox($"Instructor {arr_instructors(index_searchInstruct)} is in classroom {txt_search.Text}")
                    Exit For

                ElseIf arr_classroom(index_searchClassroom) = Nothing Then

                    'If classroom is not in the array, message box is displayed
                    MsgBox("Classroom not found")
                    Exit For

                End If
            Next
        End If
    End Sub

End Class
