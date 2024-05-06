<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormularioCrud.aspx.cs" Inherits="CapaPresentacion.FormularioCrud" %>

<!DOCTYPE html>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"
    rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"
    crossorigin="anonymous">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario</title>
</head>
<body>
    <form id="form1" runat="server">
          <h2 class="text-center">Agregando Persona</h2>
   <h2 class="text-center text-success" runat="server" id="result" style ="font-size:20px;"></h2>
    <asp:Label ID="LblId" runat="server" Text="Id"></asp:Label>
    <asp:Label ID="Label1" runat="server" Text="update" Visible="false"></asp:Label>
   <div class="container-xxl " runat="server">
        <div class="mb-3">
           <label for="exampleInputEmail1" class="form-label">Nombre</label>
                      <input id="txtNombre" type="text" placeholder="nombre" runat="server" class="form-control" />
        
         </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Apellido</label>
             <input id="txtApellido" type="text" placeholder="Apellido" runat="server" class="form-control" />
 
         </div>
        <div class="mb-3">
            <label for="exampleInputEmail1" class="form-label">Edad</label>
            <input id="txtEdad" type="text" placeholder="Edad" runat="server" class="form-control" />
         </div>
      
      
       <asp:Button ID="btn" runat="server" Text="Actualizar" OnClick="btn_Click1" CssClass="btn btn-outline-dark" />
       <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="btnEnviar_Click" CssClass="btn btn-outline-dark" />
   </div>

    <div runat="server">
        <h2 class="text-center">Listado de Persona</h2>

   
   
        <asp:GridView ID="dbGridView" runat="server" class="container-xxl">
            <Columns>

              <asp:TemplateField>
                  <ItemTemplate>
                       <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton1_Click" CssClass="btn btn-outline-primary">Editar</asp:LinkButton>
                       <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="LinkButton2_Click" CssClass="btn btn-outline-danger">Eliminar</asp:LinkButton>
                       
                  </ItemTemplate>
              </asp:TemplateField>
             
            </Columns>
            
  
      </asp:GridView>
  
    </div>
    </form>
</body>
</html>
