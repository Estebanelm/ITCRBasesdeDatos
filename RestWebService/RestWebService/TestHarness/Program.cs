// Author - Anshu Dutta
// Contact - anshu.dutta@gmail.com
using System;
using System.Xml;
using System.Web;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using L3MDB;
using Operations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
// REST Web Service Test Harness
// Contains Test Methods written for testing intermediate project
// functionalities. Comment / uncomment as needed
namespace TestHarness
{
    class Program    {   
        
        static void Main(string[] args)
        {
            Empleado emp = new Empleado();
            Sucursal suc = new Sucursal();
            string strConnString = "Data Source=LAPTOP-2E6BHQDP\\SQLEXPRESS;Initial Catalog=L3MDB;Integrated Security=True";
            Operations.Operations dal = new Operations.Operations(strConnString);



            using(SqlConnection conn = new SqlConnection(strConnString))
            {
                string sucursaltemp = "SJ45";
                string cajerotemp = "115930941";

                //////////////////////////////

                string numerotarjeta = "5";
                string codigoseguridad = "430";
                string fechaexpiraciontemp = "2027-05-22";

                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.Connection.Open();


                SqlParameter Codigo_sucursalparam = new SqlParameter("@codigo_sucursal", sucursaltemp);
                SqlParameter Cedula_cajeroparam = new SqlParameter("@cedula_cajero", int.Parse(cajerotemp));

                command.Parameters.AddRange(new SqlParameter[] { Codigo_sucursalparam, Cedula_cajeroparam });


                string listaproductosconcoma = "123456789";
                string listaCantidadesComa = "5";
                string[] listaProductosSep = listaproductosconcoma.Split(',');
                string[] listaCantidadesComaSep = listaCantidadesComa.Split(',');
                double preciodemomento = 0;
                for (int i = 0; i < listaProductosSep.Length; i++)
                {
                    string sqlGetPrecio = "SELECT Precio_venta, Cantidad FROM Producto WHERE Codigo_barras=" + listaProductosSep[i] + " AND Codigo_sucursal=@codigo_sucursal ";
                    command.CommandText = sqlGetPrecio;
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    string precioString = reader[0].ToString();
                    string cantidadDisponibleString = reader[1].ToString();
                    reader.Close();
                    double precioProducto = double.Parse(precioString);
                    int cantidadDisponible = int.Parse(cantidadDisponibleString);
                    preciodemomento = preciodemomento + (precioProducto * int.Parse(listaCantidadesComaSep[i]));
                }
                double VentaTotalSinDesc = preciodemomento;
                string sqlgetDescuento = "SELECT Descuento, Impuesto FROM Producto WHERE Codigo_sucursal=@codigo_sucursal";
                command.CommandText = sqlgetDescuento;
                SqlDataReader reader1 = command.ExecuteReader();
                reader1.Read();
                string descuentoString = reader1[0].ToString();
                string impuestoString = reader1[1].ToString();
                reader1.Close();
                int Porcentajedescuento = int.Parse(descuentoString);
                double PorcentajedescuentoDecimales = Porcentajedescuento / 100.0;
                int Porcentajeimpuesto = int.Parse(impuestoString);
                double descuentoMoneda = VentaTotalSinDesc * (Porcentajedescuento / 100.0);
                double VentaTotalconDesc = VentaTotalSinDesc - descuentoMoneda;
                double impuestoMoneda = VentaTotalconDesc * (Porcentajeimpuesto / 100.0);
                double Ventatotal = VentaTotalconDesc + impuestoMoneda;
                var request = (HttpWebRequest)WebRequest.Create("http://localhost/BancaTec/l3m?numerotarjeta=" +
                                                                    numerotarjeta + "&numeroseguridad=" +
                                                                    codigoseguridad + "&fechaexpiracion=" +
                                                                    fechaexpiraciontemp + "&monto=" +
                                                                    Ventatotal.ToString() + "&comercio=" +
                                                                    sucursaltemp);

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseString);
                XmlNode node = doc.DocumentElement.SelectSingleNode("/respuesta");
                string text = node.OuterXml.Substring(20).Split('"')[0];

                //////////////////////////////
                if (text.Equals("ok"))
                {

                    SqlCommand command1 = new SqlCommand();
                    command1.Connection = conn;
                    command1.Connection.Open();


                    SqlParameter Codigo_sucursalparam1 = new SqlParameter("@codigo_sucursal", sucursaltemp);
                    SqlParameter Cedula_cajeroparam1 = new SqlParameter("@cedula_cajero", int.Parse(cajerotemp));

                    command1.Parameters.AddRange(new SqlParameter[] { Codigo_sucursalparam1, Cedula_cajeroparam1 });

                    string sqlAddVenta = "INSERT INTO Venta (Codigo_sucursal, Cedula_cajero) VALUES (@codigo_sucursal, @cedula_cajero)";
                    command1.CommandText = sqlAddVenta;
                    command1.ExecuteNonQuery();
                    string sqlgetVentaID = "SELECT MAX(Codigo) FROM Venta ";
                    command1.CommandText = sqlgetVentaID;
                    int VentaID = (Int32)command1.ExecuteScalar();

                    string listaproductosconcoma1 = "123456789";
                    string listaCantidadesComa1 = "5";
                    string[] listaProductosSep1 = listaproductosconcoma1.Split(',');
                    string[] listaCantidadesComaSep1 = listaCantidadesComa1.Split(',');
                    for (int i = 0; i < listaProductosSep1.Length; i++)
                    {
                        string sqlGetPrecio = "SELECT Precio_venta, Cantidad FROM Producto WHERE Codigo_barras=" + listaProductosSep1[i] + " AND Codigo_sucursal=@codigo_sucursal ";
                        command1.CommandText = sqlGetPrecio;
                        SqlDataReader reader = command1.ExecuteReader();
                        reader.Read();
                        string precioString = reader[0].ToString();
                        string cantidadDisponibleString = reader[1].ToString();
                        reader.Close();
                        double precioProducto = double.Parse(precioString);
                        string nuevoProductoenVenta = "INSERT INTO Productos_en_venta (Codigo_producto, Precio_individual, Cantidad, Codigo_venta, Precio_total) VALUES (" + listaProductosSep1[i] + ", " + precioProducto.ToString() + ", " + listaCantidadesComaSep1[i] + ", " + VentaID.ToString() + ", " + (int.Parse(listaCantidadesComaSep1[i]) * precioProducto).ToString() + " ) ";
                        command1.CommandText = nuevoProductoenVenta;
                        command1.ExecuteNonQuery();
                        int cantidadDisponible = int.Parse(cantidadDisponibleString);
                        string sqlReduceCantidadProducto = "UPDATE Producto SET Cantidad=" + (cantidadDisponible - int.Parse(listaCantidadesComaSep1[i])).ToString() + " WHERE Codigo_barras=" + listaProductosSep1[i] + " AND Codigo_sucursal=@codigo_sucursal ";
                        command1.CommandText = sqlReduceCantidadProducto;
                        command1.ExecuteNonQuery();
                    }
                    string sqlgetVentaTotal = "SELECT SUM(Precio_total) FROM Productos_en_venta WHERE Codigo_venta=" + VentaID.ToString() + " ";
                    command1.CommandText = sqlgetVentaTotal;
                    SqlDataReader reader2 = command1.ExecuteReader();
                    reader2.Read();
                    string obtenerSuma = reader2[0].ToString();
                    reader2.Close();
                    double VentaTotalSinDesc1 = double.Parse(obtenerSuma);
                    string sqlgetDescuento1 = "SELECT Descuento, Impuesto FROM Producto WHERE Codigo_sucursal=@codigo_sucursal";
                    command1.CommandText = sqlgetDescuento1;
                    SqlDataReader reader11 = command1.ExecuteReader();
                    reader11.Read();
                    string descuentoString1 = reader11[0].ToString();
                    string impuestoString1 = reader11[1].ToString();
                    reader11.Close();
                    int Porcentajedescuento1 = int.Parse(descuentoString1);
                    double PorcentajedescuentoDecimales1 = Porcentajedescuento1 / 100.0;
                    int Porcentajeimpuesto1 = int.Parse(impuestoString1);
                    double descuentoMoneda1 = VentaTotalSinDesc1 * (Porcentajedescuento1 / 100.0);
                    double VentaTotalconDesc1 = VentaTotalSinDesc1 - descuentoMoneda1;
                    double impuestoMoneda1 = VentaTotalconDesc1 * (Porcentajeimpuesto1 / 100.0);
                    double Ventatotal1 = VentaTotalconDesc1 + impuestoMoneda1;
                    string sqlUpdateVenta = "UPDATE Venta SET Descuento=" + descuentoMoneda1.ToString() + ", Precio_total=" + Ventatotal1.ToString() + ", Impuesto=" + impuestoMoneda1.ToString() + " WHERE Codigo=" + VentaID.ToString() + " ";
                    command1.CommandText = sqlUpdateVenta;
                    command1.ExecuteNonQuery();
                    command1.Connection.Close();
                    string mesanje = "ok";
                }
                }



            #region "Test database Functionalities"

            //dal.DeleteEmpleado(1110);
            //dal.GetSucursal("SJ45");
            //Categoria newcat = new Categoria();
            //newcat.ID = 0;
            //newcat.Codigo_producto = 123456;
            //newcat.Descripcion = "Comida para perro";
            //dal.AddCategoria(newcat);
            //dal.GetVentas
            double descuento = 13 / 100.0;
            Console.WriteLine(descuento);
            //dal.GetHoras("17-14", 115250560);
            //TestSelectCommand(suc, dal);
            //TestInsertCommand(emp, dal);
            //TestUpdateCommand(emp, dal);
            //TestDeleteCommand(emp, dal);
            //TestXMLSerialization();

            #endregion

            #region Test HTTP Methods
            //GenerateGetRequest();
            //GeneratePOSTRequest();
            //GeneratePUTRequest();
            //GenerateDELETERequest();
            #endregion

            Console.ReadLine();
        }

        private static void TestSelectCommand(Sucursal emp, Operations.Operations dal)
        {
            Console.WriteLine("Testing Select command");
            emp = dal.GetSucursal("SJ45");
            Console.WriteLine(emp.Nombre);
        }

        private static void TestInsertCommand(Empleado emp, Operations.Operations dal)
        {
            Console.WriteLine("Testing Insert Command");
            emp = new Empleado();
            emp.Nombre = "Eva";
            emp.Pri_apellido = "Brown";
            emp.Cedula = 1110;
            emp.Seg_apellido = "Architect";
            emp.Fecha_inicio = "01/01/0101";
            emp.Fecha_nacimiento = "10/10/1010";
            emp.Salario_por_hora = 15000.02;
            emp.Sucursal = "SJ45";
            dal.AddEmpleado(emp);
            Empleado newEmp = new Empleado();
            newEmp = dal.GetEmpleado(1110);
            PrintEmployeeInformation(newEmp);           
        }

        private static void TestUpdateCommand(Empleado emp, Operations.Operations dal)
        {
            Console.WriteLine("Testing Update Command");
            emp = new Empleado();
            emp.Nombre = "Anne";
            emp.Pri_apellido = "Brown";
            emp.Cedula = 1110;
            emp.Seg_apellido = "HR";
            dal.UpdateEmpleado(emp);
            PrintEmployeeInformation(emp);
        }

        private static void TestDeleteCommand(Empleado emp, Operations.Operations dal)
        {
            Console.WriteLine("Testing Delete Command");
            dal.DeleteEmpleado(1110);
        }

        private static void PrintEmployeeInformation(Empleado emp)
        {
            Console.WriteLine("Emplyee Number - {0}", emp.Cedula);
            Console.WriteLine("Empleado First Name - {0}", emp.Nombre);
            Console.WriteLine("Empleado Last Name - {0}", emp.Pri_apellido);
            Console.WriteLine("Empleado Seg_apellido - {0}", emp.Seg_apellido);
        }

        private static void TestXMLSerialization()
        {
            Console.WriteLine("Testing Serialization.....");
            Empleado emp = new Empleado();
            emp.Nombre = "Eva";
            emp.Pri_apellido = "Brown";
            emp.Cedula = 1110;
            emp.Seg_apellido = "Architect";           
            Console.WriteLine(SerializeXML(emp));
        }

        /// <summary>
        /// Serialize XML
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        private static String SerializeXML(L3MDB.Empleado emp)
        {
            try
            {
                String XmlizedString = null;
                XmlSerializer xs = new XmlSerializer(typeof(L3MDB.Empleado));
                //create an instance of the MemoryStream class since we intend to keep the XML string 
                //in memory instead of saving it to a file.
                MemoryStream memoryStream = new MemoryStream();
                //XmlTextWriter - fast, non-cached, forward-only way of generating streams or files 
                //containing XML data
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                //Serialize emp in the xmlTextWriter
                xs.Serialize(xmlTextWriter, emp);
                //Get the BaseStream of the xmlTextWriter in the Memory Stream
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                //Convert to array
                XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch (Exception)
            {                
                throw;
            }
        }
        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            String constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        /// <summary>
        /// Test GET Method
        /// </summary>
        private static void GenerateGetRequest()
        {
            //Generate get request
            string url = "http://localhost/RESTWebService/empleado?id=115250560";
            HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create(url);
            GETRequest.Method = "GET";

            Console.WriteLine("Sending GET Request");
            HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
            Stream GETResponseStream = GETResponse.GetResponseStream();
            StreamReader sr = new StreamReader(GETResponseStream);

            Console.WriteLine("Response from Server");
            Console.WriteLine(sr.ReadToEnd());
            Console.ReadLine();
        }

        /// <summary>
        /// Test POST Method
        /// </summary>
        private static void GeneratePOSTRequest()
        {
            Console.WriteLine("Testing POST Request");
            string strURL = "http://localhost/RestWebService/employee";
            string strFirstName = "Nombre";
            string strLastName = "Pri_apellido";
            int EmpCode=111;
            string strDesignation ="Janitor";

            // The client will be oblivious to server side data type
            // So Employee class is not being used here. Code - commented
            // To send a POST request -
            // 1. Create a Employee xml object in a memory stream
            // 2. Create a HTTPRequest object with the required URL
            // 3. Set the Method Type = POST and content type = txt/xml
            // 4. Get the HTTPRequest in a stream.
            // 5. Write the xml in the content of the stream
            // 6. Get a response from the erver.

            // Through Employee Class - not recommended
            //Employee emp = new Employee();
            //emp.FirstName = strFirstName;
            //emp.LastName = strLastName;
            //emp.EmpCode = EmpCode;
            //emp.Designation = strDesignation;
            //string str = SerializeXML(emp);           

            // Create the xml document in a memory stream - Recommended       
            
            byte[] dataByte = GenerateXMLEmployee(strFirstName,strLastName,EmpCode,strDesignation);
                        
            HttpWebRequest POSTRequest = (HttpWebRequest)WebRequest.Create(strURL);
            //Method type
            POSTRequest.Method = "POST";
            // Data type - message body coming in xml
            POSTRequest.ContentType = "text/xml";
            POSTRequest.KeepAlive = false;
            POSTRequest.Timeout = 5000;
            //Content length of message body
            POSTRequest.ContentLength = dataByte.Length;

            // Get the request stream
            Stream POSTstream = POSTRequest.GetRequestStream();
            // Write the data bytes in the request stream
            POSTstream.Write(dataByte, 0, dataByte.Length);                     

            //Get response from server
            HttpWebResponse POSTResponse = (HttpWebResponse)POSTRequest.GetResponse();
            StreamReader reader = new StreamReader(POSTResponse.GetResponseStream(),Encoding.UTF8) ;
            Console.WriteLine("Response");
            Console.WriteLine(reader.ReadToEnd().ToString());           
        }

        /// <summary>
        /// Test PUT Method
        /// </summary>
        private static void GeneratePUTRequest()
        {
            Console.WriteLine("Testing PUT Request");
            string Url = "http://localhost/RestWebService/employee";
            string strFirstName = "FName";
            string strLastName = "LName";
            int EmpCode = 111;
            string strDesignation = "Assistant";

            byte[] dataByte = GenerateXMLEmployee(strFirstName, strLastName, EmpCode, strDesignation);

            HttpWebRequest PUTRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
            // Decorate the PUT request
            PUTRequest.Method = "PUT";
            PUTRequest.ContentType = "text/xml";
            PUTRequest.ContentLength = dataByte.Length;

            // Write the data byte stream into the request stream
            Stream PUTRequestStream = PUTRequest.GetRequestStream();
            PUTRequestStream.Write(dataByte,0,dataByte.Length);

            //Send request to server and get a response.
            HttpWebResponse PUTResponse = (HttpWebResponse)PUTRequest.GetResponse();
            //Get the response stream
            StreamReader PUTResponseStream = new StreamReader(PUTResponse.GetResponseStream(),Encoding.UTF8);
            Console.WriteLine(PUTResponseStream.ReadToEnd().ToString());

        }

        /// <summary>
        /// Test DELETE Method
        /// </summary>
        private static void GenerateDELETERequest()
        {
            string Url = "http://localhost/RestWebService/employee?id=111";
            HttpWebRequest DELETERequest = (HttpWebRequest)HttpWebRequest.Create(Url);
            
            DELETERequest.Method = "DELETE";
            HttpWebResponse DELETEResponse = (HttpWebResponse) DELETERequest.GetResponse();

            StreamReader DELETEResponseStream = new StreamReader(DELETEResponse.GetResponseStream(), Encoding.UTF8);
            Console.WriteLine("Response Received");
            Console.WriteLine(DELETEResponseStream.ReadToEnd().ToString());
        }

        /// <summary>
        /// Generate a Employee XML stream of bytes
        /// </summary>
        /// <param name="strFirstName"></param>
        /// <param name="strLastName"></param>
        /// <param name="intEmpCode"></param>
        /// <param name="strDesignation"></param>
        /// <returns>Employee XML in bytes</returns>
        private static byte[] GenerateXMLEmployee(string strFirstName, string strLastName, int intEmpCode, string strDesignation)
        {
            // Create the xml document in a memory stream - Recommended
            MemoryStream mStream = new MemoryStream();
            //XmlTextWriter xmlWriter = new XmlTextWriter(@"C:\Employee.xml", Encoding.UTF8);
            XmlTextWriter xmlWriter = new XmlTextWriter(mStream, Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Empleado");
            xmlWriter.WriteStartElement("Nombre");
            xmlWriter.WriteString(strFirstName);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Pri_apellido");
            xmlWriter.WriteString(strLastName);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Cedula");
            xmlWriter.WriteValue(intEmpCode);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Seg_apellido");
            xmlWriter.WriteString(strDesignation);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
            return mStream.ToArray();
        }
    }
}
