using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerLINQv2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthWindDCDataContext nwdc = new NorthWindDCDataContext();

        //
        bool pProductosClicked = false;
        bool pCategoriasClicked = false;
        bool pProveedoresClicked = false;
        
        bool pConsultasClicked = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Color de fondo
            this.BackColor = Color.FromArgb(244, 245, 250);
            //Cambia el tamaño
            this.Size = new Size(1000, 600);

            /*
            
            */

            // PANELES
            pProductos_Menu.Visible = false;
            pCategorias_Menu.Visible = false;
            pProveedores_Menu.Visible = false;
            pConsultas_Menu.Visible = false;

            pProductos_Menu.Location = new Point(70, 10);
            pCategorias_Menu.Location = new Point(70, 10);
            pProveedores_Menu.Location = new Point(70, 10);
            pConsultas_Menu.Location = new Point(70, 10);

            // PRODUCTOS
            btnAgregar_PanelProductos.BackColor = Color.FromArgb(140, 212, 126);
            btnActualizar_PanelProductos.BackColor = Color.FromArgb(248, 214, 100);
            dgvTablaProductos_PanelProductos.BackColor = Color.FromArgb(244, 245, 250);
            cbDescontinuado_PanelProductos.SelectedIndex = 0;
            cargarComboBoxIDCategorias_PanelProductos();
            cargarComboBoxIDProveedores_PanelProductos();

            // CATEGORIAS
            btnAgregar_PanelCategorias.BackColor = Color.FromArgb(140, 212, 126);
            btnActualizar_PanelCategorias.BackColor = Color.FromArgb(248, 214, 100);
            dgvTablaCategorias_PanelCategorias.BackColor = Color.FromArgb(244, 245, 250);

            // PROVEEDORES
            btnAgregarProveedor.BackColor = Color.FromArgb(140, 212, 126);
            btnActualizarProveedor.BackColor = Color.FromArgb(248, 214, 100);
            dgvProveedor.BackColor = Color.FromArgb(244, 245, 250);
        }
        //_____________________________________________________________________________________________________________________________________________
        //Metodos
        //_____________________________________________________________________________________________________________________________________________
        public void mostrarPanelProductos_Menu()
        {
            pProveedores_Menu.Visible = false;
            pCategorias_Menu.Visible = false;
            pConsultas_Menu.Visible = false;
            pProductos_Menu.Visible = true;

            cargarTablaProductos_PanelProductos();
        }
        public void mostrarPanelCategorias_Menu()
        {
            pProveedores_Menu.Visible = false;
            pProductos_Menu.Visible = false;
            pConsultas_Menu.Visible = false;
            pCategorias_Menu.Visible = true;

            cargarTablaCategorias_PanelCategorias();
        }
        public void mostrarPanelProveedores_Menu()
        {
            pCategorias_Menu.Visible = false;
            pProductos_Menu.Visible = false;
            pConsultas_Menu.Visible = false;
            pProveedores_Menu.Visible = true;

            //cargarTablaProveedores_PanelProveedores();
            cargarTablaProveedores();
        }
        public void mostrarPanelConsultas_Menu()
        {
            pCategorias_Menu.Visible = false;
            pProductos_Menu.Visible = false;
            pProveedores_Menu.Visible = false;
            pConsultas_Menu.Visible = true;

            //cargarTablaConsultas_PanelProductos();
        }

        //_____________________________________________________________________________________________________________________________________________
        //Mouse events
        //_____________________________________________________________________________________________________________________________________________
        private void mouseClick_pbProductos_Menu(object sender, EventArgs e)
        {
            mostrarPanelProductos_Menu();
            pProductosClicked = true;
            pCategoriasClicked = false;     pbCategorias_Menu.Image = Properties.Resources.categoria_bw;
            pProveedoresClicked = false;    pbProveedores_Menu.Image = Properties.Resources.proveedores_bw;
            pConsultasClicked = false;      pbConsultas_Menu.Image = Properties.Resources.query_bw;
        }
        private void mouseEnter_pbProductos_Menu(object sender, EventArgs e)     { pbProductos_Menu.Image = Properties.Resources.productos_color; }
        private void mouseLeave_pbProductos_Menu(object sender, EventArgs e)     { if (pProductosClicked == false) { pbProductos_Menu.Image = Properties.Resources.productos_bw; } }
        //_____________________________________________________________________________________________________________________________________________
        private void mouseClick_pbCategorias_Menu(object sender, EventArgs e)
        {
            mostrarPanelCategorias_Menu();
            pCategoriasClicked = true;
            pProveedoresClicked = false;    pbProveedores_Menu.Image = Properties.Resources.proveedores_bw;
            pProductosClicked = false;      pbProductos_Menu.Image = Properties.Resources.productos_bw;
            pConsultasClicked = false;      pbConsultas_Menu.Image = Properties.Resources.query_bw;
        }
        private void mouseEnter_pbCategorias_Menu(object sender, EventArgs e)    { pbCategorias_Menu.Image = Properties.Resources.categoria_color; }
        private void mouseLeave_pbCategorias_Menu(object sender, EventArgs e)    { if (pCategoriasClicked == false) { pbCategorias_Menu.Image = Properties.Resources.categoria_bw; } }
        //_____________________________________________________________________________________________________________________________________________
        private void mouseClick_pbProveedores_Menu(object sender, EventArgs e)
        {
            mostrarPanelProveedores_Menu();
            pProveedoresClicked = true;
            pCategoriasClicked = false;     pbCategorias_Menu.Image = Properties.Resources.categoria_bw;
            pProductosClicked = false;      pbProductos_Menu.Image = Properties.Resources.productos_bw;
            pConsultasClicked = false;      pbConsultas_Menu.Image = Properties.Resources.query_bw;
        }
        private void mouseEnter_pbProveedores_Menu(object sender, EventArgs e)   { pbProveedores_Menu.Image = Properties.Resources.proveedores_color; }
        private void mouseLeave_pbProveedores_Menu(object sender, EventArgs e)   { if (pProveedoresClicked == false) { pbProveedores_Menu.Image = Properties.Resources.proveedores_bw; } }
        //_____________________________________________________________________________________________________________________________________________
        private void mouseClick_pbConsultas_Menu(object sender, EventArgs e)
        {
            mostrarPanelConsultas_Menu();
            pConsultasClicked = true;
            pProveedoresClicked = false; pbProveedores_Menu.Image = Properties.Resources.proveedores_bw;
            pCategoriasClicked = false; pbCategorias_Menu.Image = Properties.Resources.categoria_bw;
            pProductosClicked = false; pbProductos_Menu.Image = Properties.Resources.productos_bw;
        }
        private void mouseEnter_pbConsultas_Menu(object sender, EventArgs e) { pbConsultas_Menu.Image = Properties.Resources.query_color; }
        private void mouseLeave_pbConsultas_Menu(object sender, EventArgs e) { if (pConsultasClicked == false) { pbConsultas_Menu.Image = Properties.Resources.query_bw; } }
        private void cargarTablaProductos_PanelProductos()
        {
            var consulta = from Prod in nwdc.Products select Prod;
            dgvTablaProductos_PanelProductos.DataSource = consulta;
        }
        private void cargarTablaCategorias_PanelCategorias()
        {
            var consulta = from Cate in nwdc.Categories select Cate;
            dgvTablaCategorias_PanelCategorias.DataSource = consulta;
        }
        private void cargarTablaProveedores_PanelProveedores()
        {

        }
        private void cargarComboBoxIDCategorias_PanelProductos()
        {
            var consulta = from Cate in nwdc.Categories select Cate;
            cbIDCategoria_PanelProductos.DataSource = consulta;
            cbIDCategoria_PanelProductos.DisplayMember = "CategoryID";
        }
        private void cargarComboBoxIDProveedores_PanelProductos()
        {
            var consulta = from Supp in nwdc.Suppliers select Supp;
            cbIDProveedor_PanelProductos.DataSource = consulta;
            cbIDProveedor_PanelProductos.DisplayMember = "SupplierID";
        }
        //_____________________________________________________________________________________________________________________________________________
        private void btnAgregar_PanelProductos_Click(object sender, EventArgs e)
        {
            Products producto = new Products();
            producto.ProductID = (int)nudIDProducto_PanelProductos.Value;
            producto.ProductName = tbNombreProducto_PanelProductos.Text;
            producto.SupplierID = Int16.Parse(cbIDProveedor_PanelProductos.GetItemText(this.cbIDProveedor_PanelProductos.SelectedItem));
            producto.CategoryID = Int16.Parse(cbIDCategoria_PanelProductos.GetItemText(this.cbIDCategoria_PanelProductos.SelectedItem));
            producto.QuantityPerUnit = tbCantidadPorUnidad_PanelProductos.Text;
            producto.UnitPrice = nudPrecioUnitario_PanelProductos.Value;
            producto.UnitsInStock = (short)nudUnidadesEnStock_PanelProductos.Value;
            producto.UnitsOnOrder = (short)nudUnidadesEnOrden_PanelProductos.Value;
            producto.ReorderLevel = (short)nudNivelDeReorden_PanelProductos.Value;
            producto.Discontinued = Convert.ToBoolean(cbDescontinuado_PanelProductos.SelectedIndex);
            nwdc.Products.InsertOnSubmit(producto);
            try     {nwdc.SubmitChanges(); cargarTablaProductos_PanelProductos();}
            catch   (Exception ex)    { MessageBox.Show("Error: " + ex.Message); }
        }
        private void btnActualizar_PanelProductos_Click(object sender, EventArgs e)
        {
            Products producto = nwdc.Products.Single(p => p.ProductID == (int)nudIDProducto_PanelProductos.Value);
            producto.ProductName = tbNombreProducto_PanelProductos.Text;
            producto.SupplierID = Int16.Parse(cbIDProveedor_PanelProductos.GetItemText(this.cbIDProveedor_PanelProductos.SelectedItem));
            producto.CategoryID = Int16.Parse(cbIDCategoria_PanelProductos.GetItemText(this.cbIDCategoria_PanelProductos.SelectedItem));
            producto.QuantityPerUnit = tbCantidadPorUnidad_PanelProductos.Text;
            producto.UnitPrice = nudPrecioUnitario_PanelProductos.Value;
            producto.UnitsInStock = (short)nudUnidadesEnStock_PanelProductos.Value;
            producto.UnitsOnOrder = (short)nudUnidadesEnOrden_PanelProductos.Value;
            producto.ReorderLevel = (short)nudNivelDeReorden_PanelProductos.Value;
            producto.Discontinued = Convert.ToBoolean(cbDescontinuado_PanelProductos.SelectedIndex);
            try { nwdc.SubmitChanges(); cargarTablaProductos_PanelProductos(); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void pbBuscar_PanelProductos_Click(object sender, EventArgs e)
        {
            try
            {
                var consulta = (from P in nwdc.Products where P.ProductID == Int32.Parse(tbBuscar_PanelProductos.Text) select P);
                dgvTablaProductos_PanelProductos.DataSource = consulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void pbBorrar_PanelProductos_Click(object sender, EventArgs e)
        {
            try
            {
                var consulta = (from P in nwdc.Products where P.ProductID.Equals(nudIDProducto_PanelProductos.Value) select P).First();
                nwdc.Products.DeleteOnSubmit(consulta);

                try { nwdc.SubmitChanges(); cargarTablaProductos_PanelProductos(); }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void pbCargar_PanelProductos_Click(object sender, EventArgs e)
        {
            if (dgvTablaProductos_PanelProductos.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTablaProductos_PanelProductos.Rows[dgvTablaProductos_PanelProductos.SelectedCells[0].RowIndex];

                var buscarProveedor = (from P in nwdc.Products
                                       where P.ProductID == Int16.Parse(Convert.ToString(selectedRow.Cells["ProductID"].Value))
                                       select P);

                nudIDProducto_PanelProductos.Text = buscarProveedor.First().ProductID.ToString();
                tbNombreProducto_PanelProductos.Text = buscarProveedor.First().ProductName.ToString();
                tbCantidadPorUnidad_PanelProductos.Text = buscarProveedor.First().QuantityPerUnit.ToString();
                nudPrecioUnitario_PanelProductos.Value = (decimal)buscarProveedor.First().UnitPrice;
                nudUnidadesEnStock_PanelProductos.Value = (decimal)buscarProveedor.First().UnitsInStock;
                nudUnidadesEnOrden_PanelProductos.Value = (decimal)buscarProveedor.First().UnitsOnOrder;
                nudNivelDeReorden_PanelProductos.Value = (decimal)buscarProveedor.First().ReorderLevel;
                cbDescontinuado_PanelProductos.SelectedIndex = Convert.ToInt16((bool)buscarProveedor.First().Discontinued);
            }
        }
        //_____________________________________________________________________________________________________________________________________________
        private void btnAgregar_PanelCategorias_Click(object sender, EventArgs e)
        {
            Categories category = new Categories();
            category.CategoryID = (int)nudIDCategoria_PanelCategorias.Value;
            category.CategoryName = tbNombreCategoria_PanelCategorias.Text;
            category.Description = tbDescripcion_PanelCategorias.Text;

            nwdc.Categories.InsertOnSubmit(category);
            try { nwdc.SubmitChanges(); cargarTablaCategorias_PanelCategorias(); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void btnActualizar_PanelCategorias_Click(object sender, EventArgs e)
        {
            Categories category = nwdc.Categories.Single(c => c.CategoryID == (int)nudIDCategoria_PanelCategorias.Value);
            category.CategoryID = (int)nudIDCategoria_PanelCategorias.Value;
            category.CategoryName = tbNombreCategoria_PanelCategorias.Text;
            category.Description = tbDescripcion_PanelCategorias.Text;
            try { nwdc.SubmitChanges(); cargarTablaCategorias_PanelCategorias(); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private void pbBuscar_PanelCategorias_Click(object sender, EventArgs e)
        {
            try
            {
                var consulta = (from C in nwdc.Categories where C.CategoryID == Int32.Parse(tbBuscar_PanelCategorias.Text) select C);
                dgvTablaCategorias_PanelCategorias.DataSource = consulta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void pbBorrar_PanelCategorias_Click(object sender, EventArgs e)
        {
            try
            {
                var consulta = (from C in nwdc.Categories where C.CategoryID.Equals(nudIDCategoria_PanelCategorias.Value) select C).First();
                nwdc.Categories.DeleteOnSubmit(consulta);

                try { nwdc.SubmitChanges(); cargarTablaCategorias_PanelCategorias(); }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void pbCargar_PanelCategorias_Click(object sender, EventArgs e)
        {
            if (dgvTablaCategorias_PanelCategorias.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvTablaCategorias_PanelCategorias.Rows[dgvTablaCategorias_PanelCategorias.SelectedCells[0].RowIndex];

                var buscarCategoria = (from C in nwdc.Categories
                                       where C.CategoryID == Int16.Parse(Convert.ToString(selectedRow.Cells["CategoryID"].Value))
                                       select C);

                nudIDCategoria_PanelCategorias.Value = buscarCategoria.First().CategoryID;
                tbNombreCategoria_PanelCategorias.Text = buscarCategoria.First().CategoryName;
                tbDescripcion_PanelCategorias.Text = buscarCategoria.First().Description;
            }
        }









        //-------------------
        private void cargarTablaProveedores()
        {
            var consulta = from Prov in nwdc.Suppliers select Prov;
            dgvProveedor.DataSource = consulta;

        }


        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Suppliers proveedor = new Suppliers();
            proveedor.SupplierID = (int)cbIDProveedorInterface.Value;
            proveedor.CompanyName = tbNombreCompania.Text;
            proveedor.ContactName = tbNombreContacto.Text;
            proveedor.ContactTitle = tbTituloContacto.Text;
            proveedor.Address = tbDireccion.Text;
            proveedor.City = tbCiudad.Text;
            proveedor.Region = tbRegion.Text;
            proveedor.PostalCode = tbCodigoPostal.Text;
            proveedor.Country = tbPais.Text;
            proveedor.Phone = tbTelefono.Text;
            proveedor.Fax = tbFax.Text;
            proveedor.HomePage = tbPaginaInicio.Text;

            nwdc.Suppliers.InsertOnSubmit(proveedor);

            try
            {
                nwdc.SubmitChanges(); // Confirmar la transaccion
                MessageBox.Show("Proveedor agregado con exito");
                cargarTablaProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        //Actualizar
        private void button2_Click(object sender, EventArgs e)
        {

            Suppliers proveedor = nwdc.Suppliers.Single(S => S.SupplierID == cbIDProveedorInterface.Value);

            proveedor.CompanyName = tbNombreCompania.Text;
            proveedor.ContactName = tbNombreContacto.Text;
            proveedor.ContactTitle = tbTituloContacto.Text;
            proveedor.Address = tbDireccion.Text;
            proveedor.City = tbCiudad.Text;
            proveedor.Region = tbRegion.Text;
            proveedor.PostalCode = tbCodigoPostal.Text;
            proveedor.Country = tbPais.Text;
            proveedor.Phone = tbTelefono.Text;
            proveedor.Fax = tbFax.Text;
            proveedor.HomePage = tbPaginaInicio.Text;

            try
            {
                nwdc.SubmitChanges(); // Confirmar la transaccion
                MessageBox.Show("Proveedor actualizado con exito");
                cargarTablaProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void pbBuscarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                var buscarProveedor = (from P in nwdc.Suppliers
                                       where P.SupplierID == Int16.Parse(txtBuscarProveedor.Text)
                                       select P);

                dgvProveedor.DataSource = buscarProveedor;
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese informacion");
            }
        }

        private void pbCargarProveedor_Click(object sender, EventArgs e)
        {
            if (dgvProveedor.SelectedCells.Count > 0)
            {
                DataGridViewRow selectedRow = dgvProveedor.Rows[dgvProveedor.SelectedCells[0].RowIndex];

                var buscarProveedor = (from S in nwdc.Suppliers
                                       where S.SupplierID == Int16.Parse(Convert.ToString(selectedRow.Cells["SupplierID"].Value))
                                       select S);

                cbIDProveedorInterface.Value = (decimal)buscarProveedor.First().SupplierID;
                tbNombreCompania.Text = buscarProveedor.First().CompanyName.ToString();
                tbNombreContacto.Text = buscarProveedor.First().ContactName.ToString();
                tbTelefono.Text = buscarProveedor.First().Phone.ToString();
                tbTituloContacto.Text = buscarProveedor.First().ContactTitle.ToString();
                tbDireccion.Text = buscarProveedor.First().Address.ToString();
                tbCiudad.Text = buscarProveedor.First().City.ToString();
                tbFax.Text = buscarProveedor.First().Fax.ToString();
                tbRegion.Text = buscarProveedor.First().Region.ToString();
                tbCodigoPostal.Text = buscarProveedor.First().PostalCode.ToString();
                tbPais.Text = buscarProveedor.First().Country.ToString();
                tbPaginaInicio.Text = buscarProveedor.First().HomePage.ToString();

            }
        }

        private void pbBorrarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                var ProveedorEliminado = (from P in nwdc.Suppliers
                                          where P.SupplierID == cbIDProveedorInterface.Value
                                          select P).First();

                nwdc.Suppliers.DeleteOnSubmit(ProveedorEliminado);

                try
                {
                    nwdc.SubmitChanges(); // Confirmar la transaccion
                    MessageBox.Show("Eliminado exitosamente");
                    cargarTablaProveedores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Revise la informacion ingresada");
            }
        }

        private void btnProy01_Click(object sender, EventArgs e)
        {
            var consulta = from P in nwdc.Products select new { P.ProductID, P.ProductName, P.UnitsInStock };
            dgvTablaConsultas.DataSource = consulta;
        }

        private void btnProy02_Click(object sender, EventArgs e)
        {
            var consulta = from S in nwdc.Suppliers select new { S.SupplierID, S.CompanyName, S.Address, S.Country };
            dgvTablaConsultas.DataSource = consulta;
        }
        private void btnLambda01_Click(object sender, EventArgs e)
        {
            var consulta = nwdc.Products.Where(P => P.ProductName == tbLambda.Text.Trim());
            dgvTablaConsultas.DataSource = consulta;
        }
        private void btnLambda02_Click(object sender, EventArgs e)
        {
            var consulta = nwdc.Products.Where(P => P.UnitsInStock >= Int16.Parse(tbLambda.Text));
            dgvTablaConsultas.DataSource = consulta;
        }
        private void btnLambda03_Click(object sender, EventArgs e)
        {
            var consulta = nwdc.Products.Where(P => P.UnitPrice >= Int16.Parse(tbLambda.Text));
            dgvTablaConsultas.DataSource = consulta;
        }

        private void btnParciales01_Click(object sender, EventArgs e)
        {
            // Nombre y producto datos concatenados con clases parciales

            var consulta = from P in nwdc.Products
                           select new
                           {
                               Codigo = P.ProductID,
                               ProductoyStock = P.ProductoDisponible()
                           };
            dgvTablaConsultas.DataSource = consulta;
        }
        private void btnParciales02_Click(object sender, EventArgs e)
        {
            // Contacto de la compania con clases parciales

            var consulta = from S in nwdc.Suppliers
                           select new
                           {
                               Codigo = S.SupplierID,
                               ProductoyStock = S.ContactoCompania()
                           };
            dgvTablaConsultas.DataSource = consulta;
        }
        private void btnParciales03_Click(object sender, EventArgs e)
        {
            // Nombre del Empleado con su titulo de cortesia, nombre, titulo con clases parciales

            var consulta = from E in nwdc.Employees
                           select new
                           {
                               Codigo = E.EmployeeID,
                               Informacion = E.EmpleadoRegistrado()
                           };
            dgvTablaConsultas.DataSource = consulta;
        }



        private void btnJoin01_Click(object sender, EventArgs e)
        {
            var consulta = from C in nwdc.Suppliers
                           join B in nwdc.Products on C.SupplierID equals B.ProductID
                           join D in nwdc.Order_Details on B.ProductID equals D.ProductID
                           join F in nwdc.Orders on D.OrderID equals F.OrderID
                           select new
                           {
                               C.CompanyName,
                               B.ProductName,
                               D.UnitPrice,
                               F.OrderDate
                           };
            dgvTablaConsultas.DataSource = consulta;
        }

        private void btnJoin02_Click(object sender, EventArgs e)
        {
            var consulta = from C in nwdc.Region
                           join B in nwdc.Territories on C.RegionID equals B.RegionID
                           join D in nwdc.EmployeeTerritories on B.TerritoryID equals D.TerritoryID
                           join F in nwdc.Employees on D.EmployeeID equals F.EmployeeID
                           select new
                           {
                               C.RegionDescription,
                               B.TerritoryDescription,
                               D.TerritoryID,
                               F.Title
                           };
            dgvTablaConsultas.DataSource = consulta;
        }

        private void btnJoin03_Click(object sender, EventArgs e)
        {
            var consulta = from C in nwdc.Categories
                           join B in nwdc.Products on C.CategoryID equals B.CategoryID
                           join D in nwdc.Order_Details on B.ProductID equals D.ProductID
                           join F in nwdc.Orders on D.OrderID equals F.OrderID
                           select new
                           {
                               C.Description,
                               B.ProductName,
                               D.Quantity,
                               F.ShipAddress
                           };
            dgvTablaConsultas.DataSource = consulta;
        }

        private void btnJoin04_Click(object sender, EventArgs e)
        {
            var consulta = from C in nwdc.Customers
                           join B in nwdc.Orders on C.CustomerID equals B.CustomerID
                           join D in nwdc.Order_Details on B.OrderID equals D.OrderID
                           join F in nwdc.Products on D.ProductID equals F.ProductID
                           select new
                           {
                               C.CompanyName,
                               B.OrderDate,
                               D.Quantity,
                               F.ProductName
                           };
            dgvTablaConsultas.DataSource = consulta;

        }
    }
}
