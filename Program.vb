Imports System
Imports System.Collections.Generic

Public Module UnemploymentModule
    Sub Main()
        ' We use a list of the Base Class (Abstraction) to hold different types of users
        Dim claimList As New List(Of BureauUser)()

        ' 1. Standard worker with a high salary and existing debt
        claimList.Add(New StandardWorker("Marko Kraljevic", 300000, 150, 15000))
        
        ' 2. Seasonal worker with a lower salary and no debt
        claimList.Add(New SeasonalWorker("Jovana Jovic", 80000, 10, 0))

        Console.WriteLine("=== COMPLETE BENEFIT PROCESSING (OOP VERSION) ===")
        Console.WriteLine(New String("-"c, 45))

        For Each user In claimList
            user.PrintCompleteReport()
            Console.WriteLine(New String("-"c, 45))
        Next
    End Sub
End Module

' BASE CLASS: Contains shared properties and core logic
' MustInherit (Abstract): You cannot create a generic "BureauUser" object.
Public MustInherit Class BureauUser
    Public Property FullName As String
    Public Property Salary As Double
    Public Property MonthsOfService As Integer
    Public Property GovernmentDebt As Double

    ' Encapsulation: Limits are hidden and protected within the class hierarchy
    Protected Const MAX_BENEFIT As Double = 120000
    Protected Const MIN_BENEFIT As Double = 40000

    Public Sub New(name As String, sal As Double, months As Integer, debt As Double)
        Me.FullName = name
        Me.Salary = sal
        Me.MonthsOfService = months
        Me.GovernmentDebt = debt
    End Sub

    ' Abstraction: Each child class must define its own duration rules
    Public MustOverride Function DetermineDurationMonths() As Integer

    ' Reusability: Shared calculation logic for all user types
    Public Function CalculateNetBenefit() As Double
        ' 1. Calculate 50% of previous salary
        Dim baseAmount As Double = Salary * 0.5
        
        ' 2. Apply Caps (Min/Max)
        Dim cappedAmount As Double = Math.Max(Math.Min(baseAmount, MAX_BENEFIT), MIN_BENEFIT)
        
        ' 3. Clawback: Subtract debt, but don't go below zero
        Return Math.Max(cappedAmount - GovernmentDebt, 0)
    End Function

    Public Sub PrintCompleteReport()
        Console.WriteLine($"User: {FullName} ({Me.GetType().Name})")
        Console.WriteLine($"Duration: {DetermineDurationMonths()} months")
        Console.WriteLine($"Net Payment (After Debt): {CalculateNetBenefit()} RSD")
    End Sub
End Class

' INHERITANCE 1: Standard Worker
Public Class StandardWorker
    Inherits BureauUser

    Public Sub New(name As String, sal As Double, months As Integer, debt As Double)
        MyBase.New(name, sal, months, debt)
    End Sub

    ' Specific logic for standard employment
    Public Overrides Function DetermineDurationMonths() As Integer
        ' Over 10 years (120 months) gets 12 months of benefits, otherwise 6
        If MonthsOfService > 120 Then Return 12 Else Return 6
    End Function
End Class

' INHERITANCE 2: Seasonal Worker
Public Class SeasonalWorker
    Inherits BureauUser

    Public Sub New(name As String, sal As Double, months As Integer, debt As Double)
        MyBase.New(name, sal, months, debt)
    End Sub

    ' Seasonal workers have a fixed shorter duration by law
    Public Overrides Function DetermineDurationMonths() As Integer
        Return 3
    End Function
End Class
