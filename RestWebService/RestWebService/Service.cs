// Author - Anshu Dutta
// Contact - anshu.dutta@gmail.com
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestWebService
{
    public class Service:IHttpHandler
    {
        #region Private Members

        private L3MDB.Empleado emp;
        private L3MDB.Sucursal suc;
        private L3MDB.Categoria cat;
        private L3MDB.Compra com;
        private L3MDB.Venta ven;
        private L3MDB.Producto produ;
        private L3MDB.Productos_en_compra producom;
        private L3MDB.Productos_en_venta produven;
        private L3MDB.Proveedor prove;
        private L3MDB.Horas hor;
        private L3MDB.Rol rol;
        private DAL.DAL dal;
        private string connString;
        private ErrorHandler.ErrorHandler errHandler;

        #endregion

        #region Handler
        bool IHttpHandler.IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        void IHttpHandler.ProcessRequest(HttpContext context)
        {
            try
            {                
                string url = Convert.ToString(context.Request.Url);
                string request_instance = url.Split('/').Last<String>().Split('?')[0];
                connString = Properties.Settings.Default.ConnectionString;
                dal = new DAL.DAL(connString);
                errHandler = new ErrorHandler.ErrorHandler();

                //Handling CRUD

                switch (context.Request.HttpMethod)
                {
                    case "GET":
                        //Perform READ Operation                   
                        READ(context, request_instance);
                        break;
                    case "POST":
                        //Perform CREATE Operation
                        CREATE(context, request_instance);
                        break;
                    case "PUT":
                        //Perform UPDATE Operation
                        UPDATE(context, request_instance);
                        break;
                    case "DELETE":
                        //Perform DELETE Operation
                        DELETE(context, request_instance);
                        break;
                    default:
                        break;
                }
                
            }
            catch (Exception ex)
            {
                
                errHandler.ErrorMessage = ex.Message.ToString();
                context.Response.Write(errHandler.ErrorMessage);                
            }
        }

        #endregion Handler

        #region CRUD Functions
        /// <summary>
        /// GET Operation
        /// </summary>
        /// <param name="context"></param>
        private void READ( HttpContext context, string request_instance)
        {
            //HTTP Request - //http://server.com/virtual directory/empleado?id={id}
            //http://localhost/RestWebService/empleado
            try
            {
                #region Empleado
                if (request_instance == "empleado")
                {
                    string _cedula_temp = context.Request["cedula"];
                    if (_cedula_temp == null)
                    {
                        List<L3MDB.Empleado> lista_empleados = dal.GetEmpleados();
                        string serializedList = Serialize(lista_empleados);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _cedula = int.Parse(_cedula_temp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        emp = dal.GetEmpleado(_cedula);
                        if (emp == null)
                            context.Response.Write(_cedula + "No Empleado Found" + context.Request["cedula"]);

                        string serializedEmpleado = Serialize(emp);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedEmpleado);
                    }
                }
                #endregion
                #region Sucursal
                else if (request_instance == "sucursal")
                {
                    string _codigo_temp = context.Request["codigo"];
                    if (_codigo_temp == null)
                    {
                        List<L3MDB.Sucursal> lista_sucursales = dal.GetSucursales();
                        string serializedList = Serialize(lista_sucursales);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        string _codigo = _codigo_temp;

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        suc = dal.GetSucursal(_codigo);
                        if (suc == null)
                            context.Response.Write(_codigo + "No Sucursal Found" + context.Request["codigo"]);

                        string serializedSucursal = Serialize(suc);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedSucursal);
                    }
                }
                #endregion
                #region Categoria
                else if (request_instance == "categoria")
                {
                    string _id_temp = context.Request["id"];
                    if (_id_temp == null)
                    {
                        List<L3MDB.Categoria> lista_categorias= dal.GetCategorias();
                        string serializedList = Serialize(lista_categorias);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _id = int.Parse(_id_temp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        cat = dal.GetCategoria(_id);
                        if (cat == null)
                            context.Response.Write(_id + "No Categoria Found" + _id_temp);

                        string serializedCategoria = Serialize(cat);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedCategoria);
                    }
                }
                #endregion
                #region Compra
                else if (request_instance == "compra")
                {
                    string _codigotemp = context.Request["codigo"];
                    if (_codigotemp == null)
                    {
                        List<L3MDB.Compra> lista_compras = dal.GetCompras();
                        string serializedList = Serialize(lista_compras);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _codigo = int.Parse(_codigotemp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        com = dal.GetCompra(_codigo);
                        if (com == null)
                            context.Response.Write(_codigo + "No Compra Found" + _codigotemp);

                        string serializedCompra = Serialize(com);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedCompra);
                    }
                }
                #endregion
                #region Horas
                else if (request_instance == "horas")
                {
                    string _horastemp = context.Request["id_semana"];
                    if (_horastemp == null)
                    {
                        List<L3MDB.Horas> lista_horas = dal.GetHorases();
                        string serializedList = Serialize(lista_horas);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        string _horas = _horastemp;

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        hor = dal.GetHoras(_horas);
                        if (com == null)
                            context.Response.Write(_horas + "No Horas Found" + _horastemp);

                        string serializedHoras = Serialize(hor);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedHoras);
                    }
                }
                #endregion
                #region Producto
                else if (request_instance == "producto")
                {
                    string _codigo_barrastemp = context.Request["codigo_barras"];
                    if (_codigo_barrastemp == null)
                    {
                        List<L3MDB.Producto> lista_productos = dal.GetProductos();
                        string serializedList = Serialize(lista_productos);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _codigo_barras = int.Parse(_codigo_barrastemp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        produ = dal.GetProducto(_codigo_barras);
                        if (produ == null)
                            context.Response.Write(_codigo_barras + "No Producto Found" + _codigo_barrastemp);

                        string serializedProducto = Serialize(produ);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedProducto);
                    }
                }
                #endregion
                #region Productos_en_compra
                else if (request_instance == "productos_en_compra")
                {
                    string _codigo_compratemp = context.Request["codigo_compra"];
                    if (_codigo_compratemp == null)
                    {
                        List<L3MDB.Productos_en_compra> lista_productos_en_compra = dal.GetProductos_en_compras();
                        string serializedList = Serialize(lista_productos_en_compra);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _codigo_compra = int.Parse(_codigo_compratemp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        producom = dal.GetProducto_en_compra(_codigo_compra);
                        if (producom == null)
                            context.Response.Write(_codigo_compra + "No Producto Found" + _codigo_compratemp);

                        string serializedProductos_en_compra = Serialize(producom);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedProductos_en_compra);
                    }
                }
                #endregion
                #region Productos_en_venta
                else if (request_instance == "productos_en_venta")
                {
                    string _codigo_ventatemp = context.Request["codigo_venta"];
                    if (_codigo_ventatemp == null)
                    {
                        List<L3MDB.Productos_en_venta> lista_productos_en_venta = dal.GetProductos_en_ventas();
                        string serializedList = Serialize(lista_productos_en_venta);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _codigo_venta = int.Parse(_codigo_ventatemp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        produven = dal.GetProducto_en_venta(_codigo_venta);
                        if (produven == null)
                            context.Response.Write(_codigo_venta + "No Producto Found" + _codigo_ventatemp);

                        string serializedProductos_en_venta = Serialize(produven);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedProductos_en_venta);
                    }
                }
                #endregion
                #region Proveedor
                else if (request_instance == "proveedor")
                {
                    string _cedulatemp = context.Request["cedula"];
                    if (_cedulatemp == null)
                    {
                        List<L3MDB.Proveedor> lista_proveedores = dal.GetProveedores();
                        string serializedList = Serialize(lista_proveedores);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _cedula = int.Parse(_cedulatemp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        prove = dal.GetProveedor(_cedula);
                        if (prove == null)
                            context.Response.Write(_cedula + "No Producto Found" + _cedulatemp);

                        string serializedProveedor = Serialize(prove);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedProveedor);
                    }
                }
                #endregion
                #region Rol
                else if (request_instance == "rol")
                {
                    string _ced_empleadotemp = context.Request["ced_empleado"];
                    if (_ced_empleadotemp == null)
                    {
                        List<L3MDB.Rol> lista_roles = dal.GetRoles();
                        string serializedList = Serialize(lista_roles);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _ced_empleado = int.Parse(_ced_empleadotemp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        rol = dal.GetRol(_ced_empleado);
                        if (rol == null)
                            context.Response.Write(_ced_empleado + "No Producto Found" + _ced_empleadotemp);

                        string serializedRol = Serialize(rol);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedRol);
                    }
                }
                #endregion
                #region Venta
                else if (request_instance == "venta")
                {
                    string _codigotemp = context.Request["codigo"];
                    if (_codigotemp == null)
                    {
                        List<L3MDB.Venta> lista_ventas = dal.GetVentas();
                        string serializedList = Serialize(lista_ventas);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedList);

                    }
                    else
                    {
                        int _codigo = int.Parse(_codigotemp);

                        //HTTP Request Type - GET"
                        //Performing Operation - READ"
                        ven = dal.GetVenta(_codigo);
                        if (ven == null)
                            context.Response.Write(_codigo + "No Producto Found" + _codigotemp);

                        string serializedVenta = Serialize(ven);
                        context.Response.ContentType = "text/xml";
                        WriteResponse(serializedVenta);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                WriteResponse(ex.Message.ToString());
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();                
            }            
        }
        /// <summary>
        /// POST Operation
        /// </summary>
        /// <param name="context"></param>
        private void CREATE(HttpContext context, string request_instance)
        {
            try
            {
                #region Empleado
                if (request_instance == "empleado")
                {

                    // HTTP POST sends name/value pairs to a web server
                    // data is sent in message body

                    //Example for this specific project
                    /*POST /RESTWebService/empleado HTTP/1.1
                      HOST: localhost
                      content-length: 163
                      content-type: application/x-www-form-urlencoded

                      Nombre=Esteban&Pri_apellido=Bambos&Seg_apellido=Bembas&Cedula=111111111&Fecha_inicio=01/01/1994&Salario_por_hora=15000.55&Fecha_nacimiento=01/01/1900&Sucursal=SJ45
                    */
                    // Extract the content of the Request and make a employee class
                    // The message body is posted as bytes. read the bytes
                    //byte[] PostData = context.Request.BinaryRead(context.Request.ContentLength);
                    //context.Request.QueryString.ToString();
                    //Convert the bytes to string using Encoding class
                    //string str = Encoding.UTF8.GetString(PostData);
                    // deserialize xml into employee class
                    L3MDB.Empleado emp = new L3MDB.Empleado(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddEmpleado(emp);
                }
                #endregion
                #region Sucursal
                else if (request_instance == "sucursal")
                {
                    L3MDB.Sucursal suc = new L3MDB.Sucursal(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddSucursal(suc);
                }
                #endregion
                #region Categoria
                else if (request_instance == "categoria")
                {
                    L3MDB.Categoria cat = new L3MDB.Categoria(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddCategoria(cat);
                }
                #endregion
                #region Compra
                else if (request_instance == "compra")
                {
                    L3MDB.Compra com = new L3MDB.Compra(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddCompra(com);
                }
                #endregion
                #region Horas
                else if (request_instance == "horas")
                {
                    L3MDB.Horas hor = new L3MDB.Horas(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddHoras(hor);
                }
                #endregion
                #region Producto
                else if (request_instance == "producto")
                {
                    L3MDB.Producto produ = new L3MDB.Producto(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddProducto(produ);
                }
                #endregion
                #region Productos_en_compra
                else if (request_instance == "productos_en_compra")
                {
                    L3MDB.Productos_en_compra producom = new L3MDB.Productos_en_compra(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddProductocompra(producom);
                }
                #endregion
                #region Productos_en_venta
                else if (request_instance == "productos_en_venta")
                {
                    L3MDB.Productos_en_venta produven = new L3MDB.Productos_en_venta(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddProductoventa(produven);
                }
                #endregion
                #region Proveedor
                else if (request_instance == "proveedor")
                {
                    L3MDB.Proveedor prove = new L3MDB.Proveedor(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddProveedor(prove);
                }
                #endregion
                #region Rol
                else if (request_instance == "rol")
                {
                    L3MDB.Rol rol = new L3MDB.Rol(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddRol(rol);
                }
                #endregion
                #region Venta
                else if (request_instance == "venta")
                {
                    L3MDB.Venta ven = new L3MDB.Venta(context);
                    //L3MDB.Empleado emp = Deserialize(PostData);                
                    // Insert data in database
                    dal.AddVenta(ven);
                }
                #endregion               
            }
            catch (Exception ex)
            {

                WriteResponse(ex.Message.ToString());
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();                
            }
        }
        /// <summary>
        /// PUT Operation
        /// </summary>
        /// <param name="context"></param>
        private void UPDATE(HttpContext context, string request_instance)
        {
            //The PUT Method

            // The PUT method requests that the enclosed entity be stored
            // under the supplied URL. If the URL refers to an already 
            // existing resource, the enclosed entity should be considered
            // as a modified version of the one residing on the origin server. 
            // If the URL does not point to an existing resource, and that 
            // URL is capable of being defined as a new resource by the 
            // requesting user agent, the origin server can create the 
            // resource with that URL.
            // If the request passes through a cache and the URL identifies 
            // one or more currently cached entities, those entries should 
            // be treated as stale. Responses to this method are not cacheable.


            // Common Problems
            // The PUT method is not widely supported on public servers 
            // due to security concerns and generally FTP is used to 
            // upload new and modified files to the webserver. 
            // Before executing a PUT method on a URL, it may be worth 
            // checking that PUT is supported using the OPTIONS method.
            
            try
            {
                #region Empleado
                if (request_instance == "empleado")
                {
                    // context.Response.Write("Update");
                    // Read the data in the message body of the PUT method
                    // The code expects the employee class as data to be updated

                    //byte[] PUTRequestByte = context.Request.BinaryRead(context.Request.ContentLength);
                    //context.Response.Write(PUTRequestByte);

                    // Deserialize Employee
                    //L3MDB.Empleado emp = Deserialize(PUTRequestByte);
                    L3MDB.Empleado emp = new L3MDB.Empleado(context);
                    dal.UpdateEmpleado(emp);
                    //context.Response.Write("Employee Updtated Sucessfully");
                    WriteResponse("ok");
                }
                #endregion
                #region Sucursal
                if (request_instance == "sucursal")
                {
                    L3MDB.Sucursal suc = new L3MDB.Sucursal(context);
                    dal.UpdateSucursal(suc);
                    WriteResponse("ok");
                }
                #endregion
                #region Categoria
                if (request_instance == "categoria")
                {
                    L3MDB.Categoria cat = new L3MDB.Categoria(context);
                    dal.UpdateCategoria(cat);
                    WriteResponse("ok");
                }
                #endregion
                #region Compra
                if (request_instance == "compra")
                {
                    L3MDB.Compra com = new L3MDB.Compra(context);
                    dal.UpdateCompra(com);
                    WriteResponse("ok");
                }
                #endregion
                #region Horas
                if (request_instance == "horas")
                {
                    L3MDB.Horas hor = new L3MDB.Horas(context);
                    dal.UpdateHoras(hor);
                    WriteResponse("ok");
                }
                #endregion
                #region Producto
                if (request_instance == "producto")
                {
                    L3MDB.Producto produ = new L3MDB.Producto(context);
                    dal.UpdateProducto(produ);
                    WriteResponse("ok");
                }
                #endregion
                #region Productos_en_compra
                if (request_instance == "productos_en_compra")
                {
                    L3MDB.Productos_en_compra producom = new L3MDB.Productos_en_compra(context);
                    dal.UpdateProductocompra(producom);
                    WriteResponse("ok");
                }
                #endregion
                #region Productos_en_venta
                if (request_instance == "productos_en_venta")
                {
                    L3MDB.Productos_en_venta produven = new L3MDB.Productos_en_venta(context);
                    dal.UpdateProductoventa(produven);
                    WriteResponse("ok");
                }
                #endregion
                #region Proveedor
                if (request_instance == "proveedor")
                {
                    L3MDB.Proveedor prove = new L3MDB.Proveedor(context);
                    dal.UpdateProveedor(prove);
                    WriteResponse("ok");
                }
                #endregion
                #region Rol
                if (request_instance == "rol")
                {
                    L3MDB.Rol rol = new L3MDB.Rol(context);
                    dal.UpdateRol(rol);
                    WriteResponse("ok");
                }
                #endregion
                #region Venta
                if (request_instance == "venta")
                {
                    L3MDB.Venta ven = new L3MDB.Venta(context);
                    dal.UpdateVenta(ven);
                    WriteResponse("ok");
                }
                #endregion
            }
            catch (Exception ex)
            {

                WriteResponse(ex.Message.ToString());
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();                
            }
        }
        /// <summary>
        /// DELETE Operation
        /// </summary>
        /// <param name="context"></param>
        private void DELETE(HttpContext context, string request_instance)
        {
            try
            {
                #region Empleado
                if (request_instance == "empleado")
                {
                    string _cedula_temp = context.Request["cedula"];
                    int _cedula = int.Parse(_cedula_temp);
                    dal.DeleteEmpleado(_cedula);
                    WriteResponse("ok");
                }
                #endregion
                #region Sucursal
                if (request_instance == "sucursal")
                {
                    string _codigo_temp = context.Request["codigo"];
                    int _codigo = int.Parse(_codigo_temp);
                    dal.DeleteSucursal(_codigo.ToString());
                    WriteResponse("ok");
                }
                #endregion
                #region Categoria
                if (request_instance == "Categoria")
                {
                    string _id_temp = context.Request["id"];
                    int _id = int.Parse(_id_temp);
                    dal.DeleteCategoria(_id);
                    WriteResponse("ok");
                }
                #endregion
                #region Compra
                if (request_instance == "compra")
                {
                    string _codigo_temp = context.Request["codigo"];
                    int _codigo = int.Parse(_codigo_temp);
                    dal.DeleteCompra(_codigo);
                    WriteResponse("ok");
                }
                #endregion
                #region Horas
                if (request_instance == "horas")
                {
                    string _id_semana_temp = context.Request["id_semana"];
                    int _id_semana = int.Parse(_id_semana_temp);
                    dal.DeleteHoras(_id_semana.ToString());
                    WriteResponse("ok");
                }
                #endregion
                #region Producto
                if (request_instance == "producto")
                {
                    string _codigo_barras_temp = context.Request["codigo_barras"];
                    int _codigo_barras = int.Parse(_codigo_barras_temp);
                    dal.DeleteProducto(_codigo_barras);
                    WriteResponse("ok");
                }
                #endregion
                #region Productos_en_compra
                if (request_instance == "productos_en_compra")
                {
                    string _codigo_compra_temp = context.Request["codigo_compra"];
                    int _codigo_compra = int.Parse(_codigo_compra_temp);
                    dal.DeleteProductocompra(_codigo_compra);
                    WriteResponse("ok");
                }
                #endregion
                #region Productos_en_venta
                if (request_instance == "productos_en_venta")
                {
                    string _codigo_venta_temp = context.Request["codigo_venta"];
                    int _codigo_venta = int.Parse(_codigo_venta_temp);
                    dal.DeleteVenta(_codigo_venta);
                    WriteResponse("ok");
                }
                #endregion
                #region Proveedor
                if (request_instance == "proveedor")
                {
                    string _cedula_temp = context.Request["cedula"];
                    int _cedula = int.Parse(_cedula_temp);
                    dal.DeleteProveedor(_cedula);
                    WriteResponse("ok");
                }
                #endregion
                #region Rol
                if (request_instance == "rol")
                {
                    string _ced_empleado_temp = context.Request["ced_empleado"];
                    int _ced_empleado = int.Parse(_ced_empleado_temp);
                    dal.DeleteRol(_ced_empleado);
                    WriteResponse("ok");
                }
                #endregion
                #region Venta
                if (request_instance == "venta")
                {
                    string _codigo_temp = context.Request["codigo"];
                    int _codigo = int.Parse(_codigo_temp);
                    dal.DeleteVenta(_codigo);
                    WriteResponse("ok");
                }
                #endregion
            }
            catch (Exception ex)
            {
                
                WriteResponse(ex.Message.ToString());
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();                
            }
        }

        #endregion

        #region Utility Functions
        /// <summary>
        /// Method - Writes into the Response stream
        /// </summary>
        /// <param name="strMessage"></param>
        private static void WriteResponse(string strMessage)
        {
            HttpContext.Current.Response.Write(strMessage);            
        }

        /// <summary>
        /// Method - Deserialize Class XML
        /// </summary>
        /// <param name="xmlByteData"></param>
        /// <returns></returns>
        private L3MDB.Empleado Deserialize(byte[] xmlByteData)
        {
            try
            {
                XmlSerializer ds = new XmlSerializer(typeof(L3MDB.Empleado));
                MemoryStream memoryStream = new MemoryStream(xmlByteData);
                L3MDB.Empleado emp = new L3MDB.Empleado();
                emp = (L3MDB.Empleado)ds.Deserialize(memoryStream);
                return emp;
            }
            catch (Exception ex)
            {
                
                errHandler.ErrorMessage = dal.GetException();
                errHandler.ErrorMessage = ex.Message.ToString();
                throw;
            }
        }

        /// <summary>
        /// Method - Serialize Class to XML
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        private String Serialize<T>(T obj)
        {
            try
            {
                String XmlizedString = null;
                XmlSerializer xs = new XmlSerializer(typeof(T));
                //create an instance of the MemoryStream class since we intend to keep the XML string 
                //in memory instead of saving it to a file.
                MemoryStream memoryStream = new MemoryStream();
                //XmlTextWriter - fast, non-cached, forward-only way of generating streams or files 
                //containing XML data
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                //Serialize emp in the xmlTextWriter
                xs.Serialize(xmlTextWriter, obj);
                //Get the BaseStream of the xmlTextWriter in the Memory Stream
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                //Convert to array
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception ex)
            {
                errHandler.ErrorMessage = ex.Message.ToString();
                throw;
            }           

        }

        /// <summary>
        /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
        /// </summary>
        /// <param name="characters">Unicode Byte Array to be converted to String</param>
        /// <returns>String converted from Unicode Byte Array</returns>
        private String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        #endregion
    }
}
