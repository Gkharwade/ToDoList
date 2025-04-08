<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ToDoList.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="row-cols-3">

                <h2>ToDo List</h2>


                <input type="text" id="Task" placeholder="Add your Task" runat="server" cssclass="form-control bg-dark w-25 h-50">


                <asp:TextBox ID="txtDate" runat="server" CssClass="m-3" TextMode="Date"></asp:TextBox>

                <asp:Button type="Button" runat="server" CssClass="btn btn-primary m-3 p-2" Text="ADD" OnClick="ADD_btn" />
            </div>
        </div>


        <asp:GridView ID="GridView1" CssClass="text-center table table-bordered table-hover" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged " OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="USERID">
    <ItemTemplate>
        <asp:Literal runat="server" ID="TASKNO"  Text='<%# Eval("TaskID") %>'></asp:Literal>
    </ItemTemplate>
</asp:TemplateField>
                <asp:TemplateField HeaderText="Task">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="TASKNAME" Text='<%# Eval("Task") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="TASKDATE">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="TASKDATE" Text='<%# Eval("TaskDate") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="STATUS">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="STATUS" Text='<%# Eval("TaskStat") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:ButtonField ButtonType="Button" CommandName="SELECT" HeaderText="Done" ShowHeader="True" Text="Done" />

                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" ShowHeader="True" Text="Delete " />
            </Columns>
        </asp:GridView>



        <%--<asp:GridView ID="GridView1" CssClass="table table-bordered border-primary table-hover" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Tasks"></asp:TemplateField>
                <itemtemplate>
                    <itemtemplate>
                        <asp:Literal ID="LiteralStdName" runat="server" Text='<%# Eval("S_name") %>'></asp:Literal>
                    </itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Marks">
                        <itemtemplate>
                            <asp:Literal ID="LiteralMarks" runat="server" Text='<%# Eval("marks") %>'></asp:Literal>
                        </itemtemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="rollno">
                        <itemtemplate>
                            <asp:Literal ID="LiteralRollNo" runat="server" Text='<%# Eval("roll_no") %>'></asp:Literal>
                        </itemtemplate>
                    </asp:TemplateField>
                </itemtemplate>

            </Columns>


        </asp:GridView>--%>
    </div>

</asp:Content>
