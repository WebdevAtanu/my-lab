'Imports System
'Imports System.Collections.Generic
'Imports System.Linq
'Imports System.Threading.Tasks

'Module Program

'    Sub Main()
'        ' =============== Basic Syntax and Data Types ===============
'        Dim name As String = "Atanu"
'        Dim age As Integer = 26
'        Dim isActive As Boolean = True

'        Console.WriteLine("Name: " & name)
'        Console.WriteLine("Age: " & age)
'        Console.WriteLine("Active: " & isActive)

'        ' =============== If Else Statement ===============
'        If age >= 18 Then
'            Console.WriteLine("Adult")
'        Else
'            Console.WriteLine("Minor")
'        End If

'        ' =============== For Loop ===============
'        For i As Integer = 1 To 5
'            Console.WriteLine("For Loop: " & i)
'        Next

'        ' =============== While Loop ===============
'        Dim j As Integer = 1
'        While j <= 3
'            Console.WriteLine("While Loop: " & j)
'            j += 1
'        End While

'        ' =============== Functions ===============
'        Dim sumResult = AddNumbers(5, 10)
'        Console.WriteLine("Sum: " & sumResult)

'        ' =============== Array ===============
'        Dim numbers() As Integer = {1, 2, 3, 4, 5}
'        For Each num In numbers
'            Console.WriteLine("Array Item: " & num)
'        Next

'        ' =============== List ===============
'        Dim fruits As New List(Of String) From {"Apple", "Banana", "Mango"}

'        fruits.Add("Orange")

'        For Each fruit In fruits
'            Console.WriteLine("Fruit: " & fruit)
'        Next

'        ' =============== Class and Object ===============
'        Dim emp As New Employee("Atanu", 50000)
'        emp.Display()

'        ' =============== Inheritance ===============
'        Dim manager As New Manager("Rahul", 80000, "IT")
'        manager.Display()

'        ' =============== Exeptions and Error Handling ===============
'        Try
'            Dim x As Integer = 10
'            Dim y As Integer = 0
'            Dim result = x \ y   ' Integer division (will throw error)
'        Catch ex As Exception
'            Console.WriteLine("Error: " & ex.Message)
'        Finally
'            Console.WriteLine("Finally block executed")
'        End Try

'        ' =============== Linq ===============
'        Dim nums = New List(Of Integer) From {10, 20, 30, 40, 50}

'        Dim filtered = nums.Where(Function(n) n > 20).ToList()

'        For Each n In filtered
'            Console.WriteLine("Filtered: " & n)
'        Next

'        ' =============== Async and Await ===============
'        Dim task = DoWorkAsync()
'        task.Wait()

'        ' =============== Delegates ===============
'        Dim calc As MathOperation = AddressOf Multiply
'        Console.WriteLine("Delegate Result: " & calc(3, 4))

'        ' =============== Events ===============
'        Dim publisher As New Publisher()
'        AddHandler publisher.MyEvent, AddressOf EventHandlerMethod

'        publisher.TriggerEvent()

'        ' =============== File Handling ===============
'        Dim path As String = "test.txt"
'        System.IO.File.WriteAllText(path, "Hello VB.NET")
'        Dim content = System.IO.File.ReadAllText(path)

'        Console.WriteLine("File Content: " & content)

'        Console.ReadLine()
'    End Sub

'    ' =============== Function Method ===============
'    Function AddNumbers(a As Integer, b As Integer) As Integer
'        Return a + b
'    End Function

'    ' =============== Async Method ===============
'    Async Function DoWorkAsync() As Task
'        Await Task.Delay(1000)
'        Console.WriteLine("Async Work Done")
'    End Function

'    ' =============== Deligate Definition ===============
'    Delegate Function MathOperation(a As Integer, b As Integer) As Integer

'    Function Multiply(a As Integer, b As Integer) As Integer
'        Return a * b
'    End Function

'    ' =============== Event Handler Method ===============
'    Sub EventHandlerMethod()
'        Console.WriteLine("Event Triggered!")
'    End Sub

'End Module

'' =============== Class Definition ===============
'Public Class Employee
'    Public Property Name As String
'    Public Property Salary As Double

'    ' Constructor
'    Public Sub New(name As String, salary As Double)
'        Me.Name = name
'        Me.Salary = salary
'    End Sub

'    Public Overridable Sub Display()
'        Console.WriteLine("Employee: " & Name & " Salary: " & Salary)
'    End Sub
'End Class

'' =============== Inheritance Example ===============
'Public Class Manager
'    Inherits Employee

'    Public Property Department As String

'    Public Sub New(name As String, salary As Double, dept As String)
'        MyBase.New(name, salary)
'        Department = dept
'    End Sub

'    Public Overrides Sub Display()
'        Console.WriteLine("Manager: " & Name & " Dept: " & Department & " Salary: " & Salary)
'    End Sub
'End Class

'' =============== Event Publisher Class ===============
'Public Class Publisher
'    Public Event MyEvent()

'    Public Sub TriggerEvent()
'        RaiseEvent MyEvent()
'    End Sub
'End Class