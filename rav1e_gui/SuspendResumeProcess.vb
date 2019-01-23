Imports System.Runtime.InteropServices

Public Class SuspendResumeProcess
    Public Enum ThreadAccess As Integer
        Terminate = &H1
        SuspendResume = &H2
        GetContext = &H8
        SetContext = &H10
        SetInformation = &H20
        QueryInformation = &H40
        SetThreadToken = &H80
        Impersonate = &H100
        DirectImpersonation = &H200
    End Enum

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function OpenThread(dwDesiredAccess As ThreadAccess, bInheritHandle As Boolean, dwThreadId As Integer) As IntPtr
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function SuspendThread(hThread As IntPtr) As UInteger
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function ResumeThread(hThread As IntPtr) As Integer
    End Function
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function CloseHandle(hObject As IntPtr) As Boolean
    End Function
    Public Shared Sub SuspendProcess(ByVal pid As Integer)
        Dim proc = Process.GetProcessById(pid)
        If proc.ProcessName = String.Empty Then Return
        For Each pT As ProcessThread In proc.Threads
            Dim pOpenThread As IntPtr = OpenThread(ThreadAccess.SuspendResume, False, CUInt(pT.Id))
            If pOpenThread = IntPtr.Zero Then
                Continue For
            End If
            SuspendThread(pOpenThread)
            CloseHandle(pOpenThread)
        Next
    End Sub
    Public Shared Sub ResumeProcess(ByVal pid As Integer)
        Dim proc = Process.GetProcessById(pid)
        If proc.ProcessName = String.Empty Then Return
        For Each pT As ProcessThread In proc.Threads
            Dim pOpenThread As IntPtr = OpenThread(ThreadAccess.SuspendResume, False, CUInt(pT.Id))
            If pOpenThread = IntPtr.Zero Then
                Continue For
            End If
            Dim suspendCount = 0
            Do
                suspendCount = ResumeThread(pOpenThread)
            Loop While suspendCount > 0
            CloseHandle(pOpenThread)
        Next
    End Sub
End Class
