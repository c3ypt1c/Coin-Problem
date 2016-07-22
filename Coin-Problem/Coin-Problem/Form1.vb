Public Class Form1
    Public Function GetWeight(CoinType) 'This means that this function will get the weight (in miligrams) from a coin type.
        If CoinType = "1p" Then
            Return 356 ' this is the weight of 1p's
            'Return basically means that the code will give out this number when this function is ran. 
        ElseIf CoinType = "2p" Then
            Return 356 'this is the weight of 2p's
        ElseIf CoinType = "5p" Then
            Return 325 'this is the weight of 5p's
        ElseIf CoinType = "10p" Then
            Return 325 'this is the weight of 10p's
        ElseIf CoinType = "20p" Then
            Return 250 'this is the weight of 20p's
        ElseIf CoinType = "50p" Then
            Return 160 'this is the weight of 50p's
        ElseIf CoinType = "£1" Then
            Return 190 'this is the weight of £1's
        ElseIf CoinType = "£2" Then
            Return 120 'this is the weight of £2's
        Else
            Return Nothing 'If it doesn't find the coin, it gives out nothing. (Avoids Null Errors)
        End If

    End Function
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Engine.Start() 'This about this like your car engine. Start it by igniting it.Then the engine does 4 stages:
        'it takes in fuel + air, compresses it, ignies it and gives out the waste. These stages repeat to drive your car. 
        'Think of the engine like this. It will do a load of calculations at a time. Every cycle it will take in the
        'numbers and generate the statistics. This is good because the program doesn't really need a trigger 
        '(eg a click or a change) in every object. This would make the code a mess. Maybe even dependant a single function
        'doing all the work. It would be desaster and living hell to refactor!! (trust me)
        'Everything Is commented below. 
    End Sub
    Private Sub Engine_Tick(sender As Object, e As EventArgs) Handles Engine.Tick
        Dim WeightPerCoin = GetWeight(ComboBox1.Text)

        NumericUpDown2.Increment = WeightPerCoin                    'Cool feature B-)

        If WeightPerCoin <> Nothing Then
            Dim IdealWeight = WeightPerCoin * NumericUpDown1.Value  'Ideal weight of the coins.
            Label6.Text = Str(IdealWeight)                          'Asignment of value

            Dim NumberOfCoins = Int(Math.Floor(NumericUpDown2.Value \ WeightPerCoin))
            'devision can make numbers NASTY!! However, it should be safe since primes in
            'WeightPerCoin() are 2 and 5. Souldn't be any reccuring decimals. It doesn't matter because
            'the numbers will be rounded down to the lowest int. (Math.Floor() "floors a float")
            Label5.Text = Str(NumberOfCoins)

            Dim SDWeight = IdealWeight - NumericUpDown2.Value 'Ideal weight - Actual Weight

            Dim SDCoins = ((NumericUpDown1.Value - NumberOfCoins) ^ 2) ^ 0.5 'Gets rid of possible minus. (because -1 * -1 is 1)
            Label8.Text = SDCoins

            If SDWeight > NumericUpDown1.Value Then
                Label7.Text = "Deficit Of"
                Label9.Text = Str(SDWeight)
            ElseIf SDWeight < NumericUpDown1.Value Then
                Label7.Text = "Surplus of"
                SDWeight = SDWeight * -1 '*-1 because it would be negative.
                Label9.Text = Str(SDWeight)
            End If
            If SDCoins = 0 Then
                Label7.Text = "Just right"
                Label8.Text = ""
                Label9.Text = ""
            End If


        Else
            'RAISE ERROR D: (Though, this really should be impossible to get to... smh if you do.)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'If Changed coin type, reset weight to zero.
        NumericUpDown2.Value = 0
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim webAddress As String = "https://github.com/c3ypt1c/Coin-Problem"
        Process.Start(webAddress)  'This is just me linking this program to github :D
    End Sub
End Class
