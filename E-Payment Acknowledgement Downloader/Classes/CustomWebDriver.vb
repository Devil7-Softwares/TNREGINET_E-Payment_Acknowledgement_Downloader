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

Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Support.UI

Public Class CustomWebDriver

#Region "Variables"
    Dim WebDriver As ChromeDriver
#End Region

#Region "Private Subs & Functions"
    Private Sub WaitForLoad()
        On Error Resume Next
        WebDriver.Manage.Timeouts.ImplicitWait = New TimeSpan(0, 0, 5)
        Dim wait As WebDriverWait = New WebDriverWait(WebDriver, New TimeSpan(10000))
        Dim Func As System.Func(Of IWebDriver, Boolean) = AddressOf CheckPageLoaded
        wait.Until(Func)
    End Sub

    Private Function CheckPageLoaded(ByVal Driver As IWebDriver) As Boolean
        Try
            Return CType(Driver, IJavaScriptExecutor).ExecuteScript("return document.readyState").Equals("complete")
        Catch ex As Exception
            Return True
        End Try
    End Function

    Private Function ClickByTitle(ByVal Title As String)
        For Each i As IWebElement In WebDriver.FindElementsByTagName("a")
            If i.GetAttribute("title") = Title Then
                i.Click()
                Return True
            End If
        Next
        Return False
    End Function

    Private Function PrintAcknowledgement(ByVal ID As Integer) As Boolean
        Dim SelectBtn As IWebElement = WebDriver.FindElementById(String.Format("rdPayment{0}", ID))
        If SelectBtn IsNot Nothing Then
            SelectBtn.Click()
        Else
            Return False
        End If

        Dim SubmitBtn As IWebElement = WebDriver.FindElementById("SubmitData")
        If SubmitBtn IsNot Nothing Then
            If SubmitBtn.GetAttribute("class") = "button_disabled" Then
                Return False
            Else
                SubmitBtn.Click()
                WaitForLoad()
            End If
        Else
            Return False
        End If

        Threading.Thread.Sleep(1000)
        Dim DownloadBtn As IWebElement = WebDriver.FindElementByLinkText("Click here")
        If DownloadBtn IsNot Nothing Then
            DownloadBtn.Click()
        Else
            Return False
        End If
        Threading.Thread.Sleep(3000)

        Return True
    End Function

    Private Function NavigatePage(ByVal ID As Integer) As Boolean
        On Error Resume Next
        Dim PageNo As Integer = Math.Ceiling(ID / 10)
        Threading.Thread.Sleep(1000)

SEARCHPAGE:
        Dim PageLinkBtn As IWebElement = Nothing
        For Each i As IWebElement In WebDriver.FindElementsByTagName("a")
            Dim Title As String = i.GetAttribute("title")
            If Title.StartsWith("Go to page ") Then
                Dim CurrentPageNo As Integer = Title.Replace("Go to page", "").Trim
                If CurrentPageNo = PageNo Then
                    i.Click()
                    Threading.Thread.Sleep(3000)
                    Return PrintAcknowledgement(ID)
                ElseIf CurrentPageNo < PageNo Then
                    PageLinkBtn = i
                End If
            End If
        Next

        If PageLinkBtn IsNot Nothing Then
            PageLinkBtn.Click()
            Threading.Thread.Sleep(3000)
            GoTo SEARCHPAGE
        End If

        Return False
    End Function
#End Region

#Region "Public Subs & Functions"
    Function Login(ByVal Username As String, ByVal Password As String) As Boolean
        ' Start Chrome Driver
        WebDriver = New ChromeDriver()

        ' Navigate to Home
        WebDriver.Navigate().GoToUrl(URLs.LOGIN)
        WaitForLoad()

        ' Change Language to English
        CType(WebDriver, IJavaScriptExecutor).ExecuteScript("javascript:changeLanguage('en');")

        ' Fill Username & Password
        Dim Username_ As IWebElement = WebDriver.FindElementById("username")
        Dim Password_ As IWebElement = WebDriver.FindElementById("password")
        Dim Captcha_ As IWebElement = WebDriver.FindElementById("txt_Captcha")
        If Username_ IsNot Nothing AndAlso Password_ IsNot Nothing AndAlso Captcha_ IsNot Nothing Then
            Username_.SendKeys(Username)
            Password_.SendKeys(Password)
            Captcha_.Click()
        Else
            MsgBox("Unable to find username element! Aborting...", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            Return False
        End If

        ' Check Whether User Entered Captcha & Successfully Logged In
        Do Until WebDriver.Url = URLs.HOME
            Application.DoEvents()
        Loop

        Return True
    End Function

    Function DownloadAcknowledgement(ByVal ID As Integer) As Boolean
        If Not ClickByTitle("E-Services") Then Return False
        If Not ClickByTitle("E-Payment") Then Return False
        If Not ClickByTitle("Print") Then Return False
        If Not ClickByTitle("Acknowledgement") Then Return False

        Threading.Thread.Sleep(3000)

        If ID <= 10 Then
            Return PrintAcknowledgement(ID)
        Else
            Return NavigatePage(ID)
        End If

        Return False
    End Function

    Function Logout() As Boolean
        On Error Resume Next
        For Each i As IWebElement In WebDriver.FindElementsByTagName("input")
            If i.GetAttribute("value") = "Sign-out" Then
                i.Click()
                Return True
            End If
        Next

        WebDriver.Quit()

        Return False
    End Function
#End Region

End Class
