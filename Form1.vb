
Public Class Form1

    Private Bitmap As Bitmap
    Private Function Cost_of_Item() As Double

        Dim Sum As Double = 0
        Dim i As Integer = 0

        For i = 0 To DataGridView1.Rows.Count - 1

            Sum = Sum + Convert.ToDouble(DataGridView1.Rows(i).Cells(2).Value)
        Next (i)
        Return Sum

    End Function

    Sub AddCost()
        Dim tax, q As Double
        tax = 3.9

        If DataGridView1.Rows.Count > 0 Then
            lblTax.Text = FormatCurrency((Cost_of_Item() * tax / 100).ToString("0.00"))
            lblSubTotal.Text = FormatCurrency(Cost_of_Item().ToString("0.00"))
            q = (Cost_of_Item() * tax / 100)
            lblTotal.Text = FormatCurrency(q + Cost_of_Item().ToString("0.00"))

        End If
    End Sub

    Sub Change()
        Dim tax, q, c As Double
        tax = 3.9

        If DataGridView1.Rows.Count > 0 Then

            q = (Cost_of_Item() * tax / 100) + Cost_of_Item()
            c = Val(lblCash.Text)
            lblChange.Text = FormatCurrency((c - q).ToString("0.00"))
        End If
    End Sub
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        lblChange.Text = ""
        lblCash.Text = "0"
        lblSubTotal.Text = ""
        lblTax.Text = ""
        lblTotal.Text = ""
        cboPayment.Text = ""
        DataGridView1.Rows.Clear()
        DataGridView1.Refresh()
    End Sub

    Private Sub NumbersOnly(sender As Object, e As EventArgs) Handles Button32.Click, Button31.Click, btnDot.Click, Button29.Click, Button27.Click, Button26.Click, Button23.Click, Button21.Click, Button20.Click, Button18.Click, Button16.Click

        Dim b As Button = sender

        If (lblCash.Text = "0") Then
            lblCash.Text = ""
            lblCash.Text = b.Text

        ElseIf (b.Text = ".") Then
            If (Not lblCash.Text.Contains(".")) Then
                lblCash.Text = lblCash.Text + b.Text
            End If
        Else
            lblCash.Text = lblCash.Text + b.Text
        End If
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        lblCash.Text = "0"
        cboPayment.Text = ""
        lblChange.Text = ""

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboPayment.Items.Add("Cash")
        cboPayment.Items.Add("Direct Debit")
        cboPayment.Items.Add("Visa")
        cboPayment.Items.Add("Master Card")

        Timer1.Enabled = True


    End Sub

    Private Sub Pay_Click(sender As Object, e As EventArgs) Handles Pay.Click
        If (cboPayment.Text = "Cash") Then


            Change()
        Else
            lblChange.Text = ""
            lblCash.Text = ""
        End If
    End Sub

    Private Sub RemoveItem_Click(sender As Object, e As EventArgs) Handles RemoveItem.Click

        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(row)
        Next
        AddCost()

        If (cboPayment.Text = "Cash") Then


            Change()
        Else
            lblChange.Text = ""
            lblCash.Text = ""
        End If
    End Sub

    Private Sub Print_Click(sender As Object, e As EventArgs) Handles Print.Click
        Dim height As Integer = DataGridView1.Height
        DataGridView1.Height = (DataGridView1.RowCount + 1) * DataGridView1.RowTemplate.Height
        Bitmap = New Bitmap(Me.DataGridView1.Width, Me.DataGridView1.Height)
        DataGridView1.DrawToBitmap(Bitmap, New Rectangle(0, 0, Me.DataGridView1.Width, Me.DataGridView1.Height))
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        PrintPreviewDialog1.ShowDialog()
        DataGridView1.Height = height

    End Sub

    Private Sub AdobongSitaw_Click(sender As Object, e As EventArgs) Handles AdobongSitaw.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Adobong Sitaw" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Adobong Sitaw", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub GinisangMongo_Click(sender As Object, e As EventArgs) Handles GinisangMongo.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Ginisang Mongo" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Ginisang Mongo", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub Chop_Suey_Click(sender As Object, e As EventArgs) Handles Chop_Suey.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Chopsuey" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Chopsuey", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub Kalderetang_Baka_Click(sender As Object, e As EventArgs) Handles Kalderetang_Baka.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Kalderetang Baka" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Kalderetang Baka", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub Bulalo_Click(sender As Object, e As EventArgs) Handles Bulalo.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Bulalo" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Bulalo", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub Bistek_Click(sender As Object, e As EventArgs) Handles Bistek.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Bistek" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Bistek", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub PorkChop_Click(sender As Object, e As EventArgs) Handles PorkChop.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Pork Chop" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Pork Chop", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub Sinigang_Click(sender As Object, e As EventArgs) Handles Sinigang.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Sinigang na Baboy" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Sinigang na Baboy", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub Sisig_Click(sender As Object, e As EventArgs) Handles Sisig.Click

        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Sisig" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Sisig", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub ChickenCurry_Click(sender As Object, e As EventArgs) Handles ChickenCurry.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Chicken Curry" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Chicken Curry", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub FriedChicken_Click(sender As Object, e As EventArgs) Handles FriedChicken.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Fried Chicken" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Fried Chicken", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub Tinola_Click(sender As Object, e As EventArgs) Handles Tinola.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Tinola" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Tinola", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub PaksiwTilapia_Click(sender As Object, e As EventArgs) Handles PaksiwTilapia.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Paksiw na Tilapia" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Paksiw na Tilapia", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub RelyenongBangus_Click(sender As Object, e As EventArgs) Handles RelyenongBangus.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Relyenong Bangus" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Relyenong Bangus", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub Galunggong_Click(sender As Object, e As EventArgs) Handles Galunggong.Click
        Dim CostOfItem As Double = 20.0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = "Fried Galunggong" Then
                row.Cells(1).Value = Double.Parse(row.Cells(1).Value + 1)
                row.Cells(2).Value = Double.Parse(row.Cells(1).Value) * CostOfItem
                Exit Sub
            End If
        Next

        DataGridView1.Rows.Add("Fried Galunggong", "1", CostOfItem)
        AddCost()

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(Bitmap, 10, 10)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTimer.Text = Date.Now.ToString("dd MMM yyyy    hh:mm:ss")
    End Sub

End Class
