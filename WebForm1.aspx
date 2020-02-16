<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="XpensesVB_Net2.WebForm1" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>


<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" type="text/css">
    <link rel="stylesheet" href="theme.css" type="text/css">
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
        }

        .auto-style3 {
            font-weight: normal;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="py-5 bg-primary" style="background-color:black; ">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <h1 class="display-4 text-light"><b>X-Penses 5.0</b></h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 bg-primary">
                        <h3 class="mb-0 text-white">Enter your expenses. Have more control over your money.</h3>
                        <h4 class="mb-0 text-white"><strong class="auto-style1">Select expenses list:</strong></h4>

                        <asp:DropDownList ID="DropDownList2" style="margin-top:20px" runat="server" class="btn btn-secondary dropdown-toggle" DataTextField="list_id" DataValueField="list_id" AutoPostBack="True">



                        </asp:DropDownList>

                        <asp:Button ID="btnDeleteList" class="btn btn-secondary m-3" style="" runat="server" Text="Delete Selected List" OnClick="btnDelecteList_Click" />
                        <asp:Button ID="btnCreateNewList" class="btn btn-secondary m-3" runat="server" Text="Create New List" OnClick="btnCreateNewList_Click" /><asp:TextBox ID="txtNewListName" runat="server" placeholder="New list name" BorderStyle="None"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="py-5">
            <div class="container">
                <div class="row">

                    <div class="col-md-3 bg-light" style="">
                        <h2 class="">Add Expense:</h2>
                        <div class="input-group">
                            <asp:TextBox ID="txtAmount" runat="server" class="form-control" placeholder="Amount" autocomplete="off"></asp:TextBox>

                        </div>

                        <div class="btn-group m-2">

                            <asp:DropDownList ID="DropDownList1" runat="server" class="btn btn-primary dropdown-toggle">
                                <asp:ListItem Value="Food">Food</asp:ListItem>
                                <asp:ListItem Value="Housing">Housing</asp:ListItem>
                                <asp:ListItem Value="Utilities">Utilities</asp:ListItem>
                                <asp:ListItem Value="Clothing">Clothing</asp:ListItem>
                                <asp:ListItem Value="Car">Car</asp:ListItem>
                                <asp:ListItem Value="Entertainment">Entertainment</asp:ListItem>
                                <asp:ListItem Value="Debt">Debt</asp:ListItem>
                                <asp:ListItem Value="Savings">Savings</asp:ListItem>
                                <asp:ListItem Value="Miscellaneous">Miscellaneous</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <h2 class="">Select date:</h2>
                                <div class="row">
                                    <div class="col-md-12">

                                        <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <h2 class="">Comments:</h2>
                                <div class="row">
                                    <div class="col-md-12">

                                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Height="71px" Width="250px"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnAdd" class="btn btn-primary m-3" runat="server" Text="Add to Selected List" OnClick="btnAdd_Click" />


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-9" style="">
                        <div class="row">
                            <div class="col-md-12">
                                <h3 class="text-center">
                                    Total Expenses:<span class="auto-style3"> $<asp:Label ID="lblTotalExpenses" runat="server" Text="Label"></asp:Label></span>
                                </h3>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="table-responsive">

                                            <asp:GridView ID="dataGridViewExpenses" style="width:100%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
                                                <AlternatingRowStyle BackColor="White" />
                                                <EditRowStyle BackColor="#2461BF" />
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EFF3FB" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            </asp:GridView>

                                            <table style="width: 100%;">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td> <h4 class="text-center"><span class="auto-style3">Total Remaining: $</span><asp:Label ID="lblTotalRemaining" runat="server" Text="Label"></asp:Label>
                                                        </h4></td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td><b> 
                        <asp:Chart ID="remainingChart" runat="server" Width="847px" Height="413px" BackImageTransparentColor="Transparent" BorderlineColor="Gray">
                            <Series>
                                <asp:Series Name="Remainings" YValuesPerPoint="4" BackImageTransparentColor="Transparent" BackSecondaryColor="Transparent" LabelForeColor="White">
                                </asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>



                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="py-5 bg-secondary">
            <div class="container">
                <b> <h4 class="mb-0 text-white"><strong class="auto-style1">Total Expenses Report: '<asp:Label ID="lblListName" runat="server" Text="Label"></asp:Label></strong>'</h4>
                <asp:Chart ID="expensesChart" runat="server" BackColor="Transparent" Height="547px" Width="728px">
                    <series>
                        <asp:Series ChartArea="Expenses" Name="Expenses" YValuesPerPoint="2" ChartType="Pie" LabelForeColor="White">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea BackColor="Transparent" Name="Expenses">
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
                <br /></b>
                <div class="row">
                   
                    </br>
                    <div class="col-md-12">
                        <h3 class="mb-0 text-white"><b>Housing: $<asp:Label ID="lblhousingCategory" runat="server" Text="Label"></asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblHousingExpensePermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblHousingRemaining" runat="server" Text="Label"></asp:Label></h4>
                        
                    </div>

                    <div class="col-md-12">
                        </br>
                        <h3 class="mb-0 text-white"><b>Food: $<asp:Label ID="lblFoodCategory" runat="server" Text="Label"></asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblFoodExpensePermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblFoodRemaining" runat="server" Text="Label"></asp:Label></h4>
                    </div>




                    <div class="col-md-12">
                        </br>
                        <h3 class="mb-0 text-white"><b>Utilities: $<asp:Label ID="lblUtilitiesCategory" runat="server" Text="Label"></b></asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblUtilitiesExpensePermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblUtilitiesRemaining" runat="server" Text="Label"></asp:Label></h4>
                    </div>



                    <div class="col-md-12">
                        </br>
                        <h3 class="mb-0 text-white"><b>Entertainment: $<asp:Label ID="lblEntertainmentCategory" runat="server" Text="Label"></b></asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblEntertainmentExpensePermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblEntertainmentRemaining" runat="server" Text="Label"></asp:Label></h4>
                    </div>

                    <div class="col-md-12">
                        </br>
                        <h3 class="mb-0 text-white"><b>Clothing: $<asp:Label ID="lblClothingCategory" runat="server" Text="Label"></b></asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblClothingExpensePermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblClothingRemaining" runat="server" Text="Label"></asp:Label></h4>
                    </div>




                    <div class="col-md-12">
                        </br>
                        <h3 class="mb-0 text-white"><b>Car: $<asp:Label ID="lblCarCategory" runat="server" Text="Label"></b></asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblCarExpensePermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblCarRemaining" runat="server" Text="Label"></asp:Label></h4>
                    </div>



                    <div class="col-md-12">
                        </br>
                        <h3 class="mb-0 text-white"><b>Debt: $<asp:Label ID="lblDebtCategory" runat="server" Text="Label"></b> </asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblDebtPermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblDebtRemaining" runat="server" Text="Label"></asp:Label></h4>
                    </div>

                    <div class="col-md-12">
                        </br>
                        <h3 class="mb-0 text-white"><b>Savings: $<asp:Label ID="lblSavingsCategory" runat="server" Text="Label"></b></asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblSavingsPermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblSavingsRemaining" runat="server" Text="Label"></asp:Label></h4>
                    </div>




                    <div class="col-md-12">
                        </br>
                        <h3 class="mb-0 text-white"><b>Miscellaneous: $<asp:Label ID="lblMiscellaneousCategory" runat="server" Text="Label"></b> </asp:Label></h3>
                        <h4 class="mb-0 text-white">• Maximun Amount: $<asp:Label ID="lblMiscellaneousPermited" runat="server" Text="Label"></asp:Label></h4>
                        <h4 class="mb-0 text-white">• Total Remaining: $<asp:Label ID="lblMiscellaneousRemaining" runat="server" Text="Label"></asp:Label></h4>
                    </div>



                </div>
            </div>
        </div>
        <div class="py-5  bg-dark">
            <div class="container">
                <div class="row">
                    <div class="fa-inverse" style=""> 
                        App Configuration:<br />
                        <br />
                        Setting up monthly take amount and percentages categories.<br />
                        <br />
                        <asp:TextBox ID="txtMonthlyTake" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Monthly Take Amount<br />
                        <br />
                        <asp:TextBox ID="txtHousingPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Housing Percentage<br />
                        <br />
                        <b>
                        <asp:TextBox ID="txtFoodPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Food Percentage</b><br />
                        <br />
                        <b>
                        <asp:TextBox ID="txtUtilitiesPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Utilities Percentage</b><br />
                        <br />
                        <b>
                        <asp:TextBox ID="txtCarPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Car Percentage</b><br />
                        <br />
                        <b>
                        <asp:TextBox ID="txtDebtPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Debt Percentage<br />
                        <br />
                        <asp:TextBox ID="txtSavingsPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Savings Percentage<br />
                        <br />
                        <asp:TextBox ID="txtClothingPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Clothing Percentage<br />
                        <br />
                        <asp:TextBox ID="txtEntertainmentPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Entertainment Percentage<br />
                        <br />
                        <asp:TextBox ID="txtMiscellaneousPercent" runat="server" BorderStyle="None" Enabled="False"></asp:TextBox>
&nbsp;Miscellaneous Percent</b><br />
                        <br />
                        <br />
                        <asp:Button ID="btnEditConfiguration" class="btn btn-secondary m-3" runat="server" Text="Edit Configuration" OnClick="btnCreateNewList_Click" />
                        <br />
                        <b>
                        <asp:Button ID="btnSaveConfiguration" class="btn btn-secondary m-3" runat="server" Text="Save Configuration" OnClick="btnCreateNewList_Click" /></b>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>

    </form>


    <script>
        function myFunction() {
          var newList = prompt("Please enter list name:");
        }
    </script>

</body>

</html>
