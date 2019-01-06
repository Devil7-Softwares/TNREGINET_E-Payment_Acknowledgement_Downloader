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
Imports DevExpress.XtraEditors.Controls

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

            txt_DownloadLocation.Enabled = True

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

            txt_DownloadLocation.Enabled = False

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

    Private Sub txt_DownloadLocation_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txt_DownloadLocation.ButtonClick
        dlg_SelectDownloadLocation.SelectedPath = txt_DownloadLocation.Text
        If dlg_SelectDownloadLocation.ShowDialog = DialogResult.OK Then
            txt_DownloadLocation.Text = dlg_SelectDownloadLocation.SelectedPath
            My.Settings.DownloadLocation = dlg_SelectDownloadLocation.SelectedPath
            My.Settings.Save()
        End If
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

        Dim Driver As New CustomWebDriver(txt_DownloadLocation.Text)
        AddHandler Driver.ReportStatus, AddressOf ReportStatus
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
            txt_Password.Text = My.Settings.Password
        End If
        If My.Settings.DownloadLocation = "" Or Not My.Computer.FileSystem.DirectoryExists(My.Settings.DownloadLocation) Then
            txt_DownloadLocation.Text = My.Computer.FileSystem.SpecialDirectories.Desktop
            My.Settings.DownloadLocation = My.Computer.FileSystem.SpecialDirectories.Desktop
            My.Settings.Save()
        Else
            txt_DownloadLocation.Text = My.Settings.DownloadLocation
        End If
    End Sub

    Private Sub chk_SavePassword_CheckedChanged(sender As Object, e As EventArgs) Handles chk_SavePassword.CheckedChanged
        My.Settings.SaveUsername = chk_SavePassword.Checked
        My.Settings.Save()
    End Sub

    Private Sub ReportStatus(ByVal Message As String, ByVal Color As Color)
        If InvokeRequired Then
            Invoke(Sub() ReportStatus(Message, Color))
        Else
            txt_Console.SelectionColor = Color
            txt_Console.AppendText(Message)
            PostMessage(txt_Console.Handle, WM_VSCROLL, CType(SB_BOTTOM, IntPtr), CType(IntPtr.Zero, IntPtr))
        End If
    End Sub
#End Region

End Class