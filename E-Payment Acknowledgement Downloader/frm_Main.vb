'=========================================================================='
'                                                                          '
'                    (C) Copyright 2018 Devil7 Softwares.                  '
'                                                                          '
' Licensed under the Apache License, Version 2.0 (the "License");          '
' you may not use this file except in compliance with the License.         '
' You may obtain a copy of the License at                                  '
'                                                                          '
'                http://www.apache.org/licenses/LICENSE-2.0                '
'                                                                          '
' Unless required by applicable law or agreed to in writing, software      '
' distributed under the License is distributed on an "AS IS" BASIS,        '
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. '
' See the License for the specific language governing permissions and      '
' limitations under the License.                                           '
'                                                                          '
' Contributors :                                                           '
'     Dineshkumar T                                                        '
'                                                                          '
'=========================================================================='

Imports System.ComponentModel

Public Class frm_Main

#Region "Subs"
    Sub EnableControls()
        If InvokeRequired Then
            Invoke(Sub() EnableControls())
        Else
            txt_Username.Enabled = True
            txt_Password.Enabled = True

            chk_SavePassword.Enabled = True

            txt_Serial_From.Enabled = True
            txt_Serial_To.Enabled = True

            btn_Start.Enabled = True

            TopMost = False
        End If
    End Sub

    Sub DisableControls()
        If InvokeRequired Then
            Invoke(Sub() DisableControls())
        Else
            txt_Username.Enabled = False
            txt_Password.Enabled = False

            chk_SavePassword.Enabled = False

            txt_Serial_From.Enabled = False
            txt_Serial_To.Enabled = False

            btn_Start.Enabled = False

            Location = New Point(My.Computer.Screen.WorkingArea.Width - Width, My.Computer.Screen.WorkingArea.Height - Height)
            TopMost = True
        End If
    End Sub
#End Region

#Region "Button Events"
    Private Sub btn_Start_Click(sender As Object, e As EventArgs) Handles btn_Start.Click
        If Not DownloadWorker.IsBusy Then DownloadWorker.RunWorkerAsync()
    End Sub
#End Region

#Region "Other Events"
    Private Sub DownloadWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles DownloadWorker.DoWork
        If txt_Username.Text.Trim = "" Or txt_Password.Text.Trim = "" Then
            Invoke(Sub() MsgBox("Username and Password cannot be empty!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error"))
            Exit Sub
        End If

        If My.Settings.SaveUsername Then
            My.Settings.Username = txt_Username.Text
            My.Settings.Password = txt_Password.Text
            My.Settings.Save()
        End If

        DisableControls()

        Dim Driver As New CustomWebDriver
        If Not Driver.Login(txt_Username.Text, txt_Password.Text) Then Exit Sub

        For ID As Integer = txt_Serial_From.Value To txt_Serial_To.Value
            Driver.DownloadAcknowledgement(ID)
        Next

        Driver.Logout()

        EnableControls()
    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        chk_SavePassword.Checked = My.Settings.SaveUsername
        If My.Settings.SaveUsername Then
            txt_Username.Text = My.Settings.Username
            txt_Password.Text = My.Settings.password
        End If
    End Sub

    Private Sub chk_SavePassword_CheckedChanged(sender As Object, e As EventArgs) Handles chk_SavePassword.CheckedChanged
        My.Settings.saveusername = chk_SavePassword.Checked
        My.Settings.Save()
    End Sub
#End Region

End Class