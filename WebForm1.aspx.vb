Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.Xml
Imports System.Web.UI.DataVisualization.Charting

Public Class WebForm1
    Inherits System.Web.UI.Page
    Public conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
    'Public conn As New SqlConnection With {.ConnectionString = "Data Source=R2-10\SQLEXPRESS;Initial Catalog=DBPractice;Integrated Security=True"}
    Dim cmd As New SqlCommand
    Dim dt As New DataTable
    Dim ad As New SqlDataAdapter




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack Then
            Calendar1.SelectedDate = DateTime.Now.Date
            'gridDisplay()
            'getMaxAmounts()
            'getExpenses()
            'getRemainings()
        Else
            Calendar1.SelectedDate = DateTime.Now.Date
            getExpensesLists()
            gridDisplay()
            getMaxAmounts()
            getExpenses()
            getRemainings()
        End If

    End Sub

    Private Sub getExpensesLists()
        Try
            Dim cmd = New SqlCommand("Select list_id from lists", conn)
            conn.Open()
            ad = New SqlDataAdapter(cmd)
            dt = New DataTable
            ad.Fill(dt)
            DropDownList2.DataSource = dt
            DropDownList2.DataTextField = "list_id"
            DropDownList2.DataValueField = "list_id"
            DropDownList2.DataBind()
            DropDownList2.SelectedIndex = DropDownList2.Items.Count - 1
            conn.Close()

            lblListName.Text = DropDownList2.SelectedValue.ToString

        Catch ex As Exception

        End Try

    End Sub

    Private Sub getExpenses()

        'Dim expensesDocXML As XmlDocument
        Try
            Dim cmd As New SqlCommand("USP_GET_TOTALS_EXPENSES", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@selectedList", DropDownList2.SelectedValue.ToString)
            conn.Open()
            ad = New SqlDataAdapter(cmd)
            dt = New DataTable
            ad.Fill(dt)

            If dt.Rows.Count > 0 Then
                lblTotalExpenses.Text = dt.Rows(0)("TOTAL_EXPENSES").ToString
                lblhousingCategory.Text = dt.Rows(0)("TOTAL_HOUSING").ToString

                lblFoodCategory.Text = dt.Rows(0)("TOTAL_FOOD").ToString
                lblUtilitiesCategory.Text = dt.Rows(0)("TOTAL_UTILITIES").ToString

                lblCarCategory.Text = dt.Rows(0)("TOTAL_CAR").ToString
                lblClothingCategory.Text = dt.Rows(0)("TOTAL_CLOTHING").ToString

                lblDebtCategory.Text = dt.Rows(0)("TOTAL_DEBT").ToString
                lblEntertainmentCategory.Text = dt.Rows(0)("TOTAL_ENTERTAINMENT").ToString

                lblMiscellaneousCategory.Text = dt.Rows(0)("TOTAL_MISCELANEOUS").ToString
                lblSavingsCategory.Text = dt.Rows(0)("TOTAL_SAVINGS").ToString

                'expensesChart.Series("Expenses").LabelFormat = "{#'%'}"
                'expensesChart.Legends.Add("Expenses")
                'expensesChart.Series("Expenses").IsValueShownAsLabel = True
                expensesChart.Series("Expenses")("PieLabelStyle") = "Outside"
                expensesChart.ChartAreas("Expenses").Area3DStyle.Enable3D = True
                expensesChart.ChartAreas("Expenses").Area3DStyle.Inclination = 10
                expensesChart.Series("Expenses").Points.AddXY("HOUSING = " + dt.Rows(1)("TOTAL_HOUSING").ToString + "%", dt.Rows(0)("TOTAL_HOUSING"))
                expensesChart.Series("Expenses").Points.AddXY("FOOD = " + dt.Rows(1)("TOTAL_FOOD").ToString + "%", dt.Rows(0)("TOTAL_FOOD"))
                expensesChart.Series("Expenses").Points.AddXY("UTILITIES = " + dt.Rows(1)("TOTAL_UTILITIES").ToString + "%", dt.Rows(0)("TOTAL_UTILITIES"))
                expensesChart.Series("Expenses").Points.AddXY("CAR = " + dt.Rows(1)("TOTAL_CAR").ToString + "%", dt.Rows(0)("TOTAL_CAR"))
                expensesChart.Series("Expenses").Points.AddXY("CLOTHING = " + dt.Rows(1)("TOTAL_CLOTHING").ToString + "%", dt.Rows(0)("TOTAL_CLOTHING"))
                expensesChart.Series("Expenses").Points.AddXY("DEBT = " + dt.Rows(1)("TOTAL_DEBT").ToString + "%", dt.Rows(0)("TOTAL_DEBT"))
                expensesChart.Series("Expenses").Points.AddXY("ENTERTAINMENT = " + dt.Rows(1)("TOTAL_ENTERTAINMENT").ToString + "%", dt.Rows(0)("TOTAL_ENTERTAINMENT"))
                expensesChart.Series("Expenses").Points.AddXY("MISCELANEOUS= " + dt.Rows(1)("TOTAL_MISCELANEOUS").ToString + "%", dt.Rows(0)("TOTAL_MISCELANEOUS"))
                expensesChart.Series("Expenses").Points.AddXY("SAVINGS = " + dt.Rows(1)("TOTAL_SAVINGS").ToString + "%", dt.Rows(0)("TOTAL_SAVINGS"))

                'For Each dp As DataPoint In expensesChart.Series("Expenses").Points
                '    If dp.YValues("TOTAL_UTILITIES") = 0 Then
                '        dp.IsValueShownAsLabel = False
                '    End If
                'Next

            End If

            conn.Close()
        Catch ex As Exception
            ex.ToString()

        End Try



    End Sub

    Private Sub gridDisplay()
        Try
            cmd = New SqlCommand("USP_SELECT_DISPLAY", conn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@userSelection", DropDownList2.SelectedValue.ToString)
            conn.Open()
            ad = New SqlDataAdapter(cmd)
            dt = New DataTable
            ad.Fill(dt)
            dataGridViewExpenses.DataSource = dt
            dataGridViewExpenses.DataBind()
            conn.Close()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub getMaxAmounts()
        Try

            Dim cmd As New SqlCommand("USP_GET_MAX_AMOUNTS", conn)
            cmd.CommandType = CommandType.StoredProcedure
            conn.Open()
            ad = New SqlDataAdapter(cmd)
            dt = New DataTable
            ad.Fill(dt)

            If dt.Rows.Count > 0 Then


                lblHousingExpensePermited.Text = dt.Rows(0)("housing_max").ToString

                lblFoodExpensePermited.Text = dt.Rows(0)("food_max").ToString
                lblUtilitiesExpensePermited.Text = dt.Rows(0)("utilities_max").ToString

                lblCarExpensePermited.Text = dt.Rows(0)("car_max").ToString
                lblClothingExpensePermited.Text = dt.Rows(0)("clothing_max").ToString

                lblDebtPermited.Text = dt.Rows(0)("debt_max").ToString
                lblEntertainmentExpensePermited.Text = dt.Rows(0)("entertainment_max").ToString
                lblFoodExpensePermited.Text = dt.Rows(0)("food_max").ToString

                lblMiscellaneousPermited.Text = dt.Rows(0)("miscellaneous_max").ToString
                lblSavingsPermited.Text = dt.Rows(0)("savings_max").ToString


                'configuration text Boxes--------------------------
                txtMonthlyTake.Text = dt.Rows(0)("monthly_take").ToString
                txtHousingPercent.Text = dt.Rows(0)("housing_percent").ToString
                txtFoodPercent.Text = dt.Rows(0)("food_percent").ToString
                txtUtilitiesPercent.Text = dt.Rows(0)("utilities_percent").ToString

                txtCarPercent.Text = dt.Rows(0)("car_percent").ToString
                txtClothingPercent.Text = dt.Rows(0)("clothing_percent").ToString

                txtDebtPercent.Text = dt.Rows(0)("debt_percent").ToString
                txtEntertainmentPercent.Text = dt.Rows(0)("entertainment_percent").ToString

                txtMiscellaneousPercent.Text = dt.Rows(0)("miscellaneous_percent").ToString
                txtSavingsPercent.Text = dt.Rows(0)("savings_percent").ToString


            End If

            conn.Close()


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList2.SelectedIndexChanged
        lblListName.Text = DropDownList2.SelectedValue.ToString
        'getExpensesLists()
        gridDisplay()
        getMaxAmounts()
        getExpenses()
        getRemainings()
    End Sub

    Protected Sub btnDelecteList_Click(sender As Object, e As EventArgs) Handles btnDeleteList.Click
        Dim Sql As String = "delete from lists where list_id='" + DropDownList2.SelectedValue + "'"

        conn.Open()
        cmd = New SqlCommand(Sql, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        getExpensesLists()
        gridDisplay()
        getMaxAmounts()
        getExpenses()
        getRemainings()
    End Sub

    Protected Sub btnCreateNewList_Click(sender As Object, e As EventArgs) Handles btnCreateNewList.Click

        Dim Sql As String = "insert into lists(list_id) values('" + txtNewListName.Text + "')"

        conn.Open()
        cmd = New SqlCommand(Sql, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
        getExpensesLists()
        gridDisplay()
        getMaxAmounts()
        getExpenses()
        getRemainings()
    End Sub

    Protected Sub btnSaveConfiguration_Click(sender As Object, e As EventArgs) Handles btnSaveConfiguration.Click


        Try
            If percetnValidation() Then

                Dim Sql As String = "Update EXPENSES_CONFIG set monthlyTake=" + txtMonthlyTake.Text + ",housingPercent=" + txtHousingPercent.Text + "
                                ,foodPercent=" + txtFoodPercent.Text + "
                                ,carPercent=" + txtCarPercent.Text + "
                                ,debtPercent=" + txtDebtPercent.Text + "
                                ,savingsPercent=" + txtSavingsPercent.Text + "
                                ,clothingPercent=" + txtClothingPercent.Text + "
                                ,entertainmentPercent=" + txtEntertainmentPercent.Text + "
                                ,miscellaneousPercent=" + txtMiscellaneousPercent.Text + "
                                ,utilitiesPercent=" + txtUtilitiesPercent.Text + ""

                conn.Open()
                cmd = New SqlCommand(Sql, conn)
                cmd.ExecuteNonQuery()
                conn.Close()

                txtMonthlyTake.Enabled = False
                txtHousingPercent.Enabled = False
                txtFoodPercent.Enabled = False
                txtUtilitiesPercent.Enabled = False
                txtCarPercent.Enabled = False
                txtDebtPercent.Enabled = False
                txtSavingsPercent.Enabled = False
                txtClothingPercent.Enabled = False
                txtEntertainmentPercent.Enabled = False
                txtMiscellaneousPercent.Enabled = False

                gridDisplay()
                getMaxAmounts()
                getExpenses()
                getRemainings()

            End If
        Catch ex As Exception

        End Try
    End Sub



    Protected Sub btnEditConfiguration_Click(sender As Object, e As EventArgs) Handles btnEditConfiguration.Click
        txtMonthlyTake.Enabled = True
        txtHousingPercent.Enabled = True
        txtFoodPercent.Enabled = True
        txtUtilitiesPercent.Enabled = True
        txtCarPercent.Enabled = True
        txtDebtPercent.Enabled = True
        txtSavingsPercent.Enabled = True
        txtClothingPercent.Enabled = True
        txtEntertainmentPercent.Enabled = True
        txtMiscellaneousPercent.Enabled = True

        gridDisplay()
        getMaxAmounts()
        getExpenses()
        getRemainings()
    End Sub

    Private Function percetnValidation() As Boolean
        Dim housingPercent As Decimal = txtHousingPercent.Text
        Dim foodPercent As Decimal = txtFoodPercent.Text
        Dim carPercent As Decimal = txtCarPercent.Text
        Dim debtPercent As Decimal = txtDebtPercent.Text
        Dim savingsPercent As Decimal = txtSavingsPercent.Text
        Dim clothingPercent As Decimal = txtClothingPercent.Text
        Dim entertainmentPercent As Decimal = txtEntertainmentPercent.Text
        Dim miscellaneousPercent As Decimal = txtMiscellaneousPercent.Text
        Dim utilitiesPercent As Decimal = txtUtilitiesPercent.Text

        Dim totalPercent As Decimal = housingPercent + foodPercent + carPercent + debtPercent + savingsPercent +
                                        clothingPercent + entertainmentPercent + miscellaneousPercent + utilitiesPercent

        If totalPercent = 1 Then Return True

    End Function

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim Sql As String = "Insert into expenses values(" + txtAmount.Text + ", '" + Calendar1.SelectedDate + "' , '" + DropDownList1.SelectedValue + "', '" + txtComments.Text + "', '" + DropDownList2.SelectedValue + "',  ''  )"

            conn.Open()
            cmd = New SqlCommand(Sql, conn)
            cmd.ExecuteNonQuery()
            conn.Close()

            gridDisplay()
            getMaxAmounts()
            getExpenses()
            getRemainings()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub getRemainings()
        Dim totalRemaining = Convert.ToDecimal(txtMonthlyTake.Text) - Convert.ToDecimal(lblTotalExpenses.Text)
        lblTotalRemaining.Text = totalRemaining.ToString()

        Dim housingRemaining = Convert.ToDecimal(lblHousingExpensePermited.Text) - Convert.ToDecimal(lblhousingCategory.Text)
        lblHousingRemaining.Text = housingRemaining.ToString()

        Dim foodRemaining = Convert.ToDecimal(lblFoodExpensePermited.Text) - Convert.ToDecimal(lblFoodCategory.Text)
        lblFoodRemaining.Text = foodRemaining.ToString()

        Dim entertainmentRemaining = Convert.ToDecimal(lblEntertainmentExpensePermited.Text) - Convert.ToDecimal(lblEntertainmentCategory.Text)
        lblEntertainmentRemaining.Text = entertainmentRemaining.ToString()

        Dim clothingRemaining = Convert.ToDecimal(lblClothingExpensePermited.Text) - Convert.ToDecimal(lblClothingCategory.Text)
        lblClothingRemaining.Text = clothingRemaining.ToString()

        Dim utilitiesRemaining = Convert.ToDecimal(lblUtilitiesExpensePermited.Text) - Convert.ToDecimal(lblUtilitiesCategory.Text)
        lblUtilitiesRemaining.Text = utilitiesRemaining.ToString()

        Dim carRemaining = Convert.ToDecimal(lblCarExpensePermited.Text) - Convert.ToDecimal(lblCarCategory.Text)
        lblCarRemaining.Text = carRemaining.ToString()

        Dim debtRemaining = Convert.ToDecimal(lblDebtPermited.Text) - Convert.ToDecimal(lblDebtCategory.Text)
        lblDebtRemaining.Text = debtRemaining.ToString()

        Dim savingsRemaining = Convert.ToDecimal(lblSavingsPermited.Text) - Convert.ToDecimal(lblSavingsCategory.Text)
        lblSavingsRemaining.Text = savingsRemaining.ToString()

        Dim miscellaneousRemaining = Convert.ToDecimal(lblMiscellaneousPermited.Text) - Convert.ToDecimal(lblMiscellaneousCategory.Text)
        lblMiscellaneousRemaining.Text = miscellaneousRemaining.ToString()

        remainingChart.Series("Remainings").Points.AddXY("HOUSING: \n$" + lblHousingRemaining.Text, lblHousingRemaining.Text)
        remainingChart.Series("Remainings").Points.AddXY("FOOD: \n$" + lblFoodRemaining.Text, lblFoodRemaining.Text)
        remainingChart.Series("Remainings").Points.AddXY("UTILITIES: \n$" + lblUtilitiesRemaining.Text, lblUtilitiesRemaining.Text)
        remainingChart.Series("Remainings").Points.AddXY("CAR: \n$" + lblCarRemaining.Text, lblCarRemaining.Text)
        remainingChart.Series("Remainings").Points.AddXY("CLOTHING: \n$" + lblClothingRemaining.Text, lblClothingRemaining.Text)
        remainingChart.Series("Remainings").Points.AddXY("DEBT: \n$" + lblDebtRemaining.Text, lblDebtRemaining.Text)
        remainingChart.Series("Remainings").Points.AddXY("ENTERTAINMENT: \n$" + lblEntertainmentRemaining.Text, lblEntertainmentRemaining.Text)
        remainingChart.Series("Remainings").Points.AddXY("MISCELANEOUS: \n$" + lblMiscellaneousRemaining.Text, lblMiscellaneousRemaining.Text)
        remainingChart.Series("Remainings").Points.AddXY("SAVINGS: \n$" + lblSavingsRemaining.Text, lblSavingsRemaining.Text)

    End Sub
End Class