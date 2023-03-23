
namespace SIEClinica.Informes.Reportes
{
    partial class Report1
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group2 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group3 = new Telerik.Reporting.Group();
            Telerik.Reporting.Group group4 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule5 = new Telerik.Reporting.Drawing.StyleRule();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.labelsGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.labelsGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.ventaCaptionTextBox = new Telerik.Reporting.TextBox();
            this.pacienteCaptionTextBox = new Telerik.Reporting.TextBox();
            this.nombrePacienteCaptionTextBox = new Telerik.Reporting.TextBox();
            this.productoCaptionTextBox = new Telerik.Reporting.TextBox();
            this.descripCaptionTextBox = new Telerik.Reporting.TextBox();
            this.cantidadCaptionTextBox = new Telerik.Reporting.TextBox();
            this.importeCaptionTextBox = new Telerik.Reporting.TextBox();
            this.ventaGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.ventaGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.pacienteGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.pacienteGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.nombrePacienteGroupHeaderSection = new Telerik.Reporting.GroupHeaderSection();
            this.nombrePacienteGroupFooterSection = new Telerik.Reporting.GroupFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.pageHeader = new Telerik.Reporting.PageHeaderSection();
            this.reportNameTextBox = new Telerik.Reporting.TextBox();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.reportFooter = new Telerik.Reporting.ReportFooterSection();
            this.detail = new Telerik.Reporting.DetailSection();
            this.productoDataTextBox = new Telerik.Reporting.TextBox();
            this.descripDataTextBox = new Telerik.Reporting.TextBox();
            this.cantidadDataTextBox = new Telerik.Reporting.TextBox();
            this.importeDataTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "Data Source=.\\SQLServer2014;Initial Catalog=SIEClinica;Integrated Security=True";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@FechaIni", System.Data.DbType.Date, "= Parameters.FechaIni.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@FechaFin", System.Data.DbType.Date, "= Parameters.FechaIni.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Producto", System.Data.DbType.AnsiString, "= Parameters.Producto.Value"),
            new Telerik.Reporting.SqlDataSourceParameter("@Cliente", System.Data.DbType.AnsiString, "= Parameters.Cliente.Value")});
            this.sqlDataSource1.ProviderName = "System.Data.SqlClient";
            this.sqlDataSource1.SelectCommand = "dbo.ReporteVentasDetallado";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // labelsGroupHeaderSection
            // 
            this.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.labelsGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ventaCaptionTextBox,
            this.pacienteCaptionTextBox,
            this.nombrePacienteCaptionTextBox,
            this.productoCaptionTextBox,
            this.descripCaptionTextBox,
            this.cantidadCaptionTextBox,
            this.importeCaptionTextBox});
            this.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection";
            this.labelsGroupHeaderSection.PrintOnEveryPage = true;
            // 
            // labelsGroupFooterSection
            // 
            this.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.labelsGroupFooterSection.Name = "labelsGroupFooterSection";
            this.labelsGroupFooterSection.Style.Visible = false;
            // 
            // ventaCaptionTextBox
            // 
            this.ventaCaptionTextBox.CanGrow = true;
            this.ventaCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.053D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.ventaCaptionTextBox.Name = "ventaCaptionTextBox";
            this.ventaCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.ventaCaptionTextBox.StyleName = "Caption";
            this.ventaCaptionTextBox.Value = "venta";
            // 
            // pacienteCaptionTextBox
            // 
            this.pacienteCaptionTextBox.CanGrow = true;
            this.pacienteCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.543D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.pacienteCaptionTextBox.Name = "pacienteCaptionTextBox";
            this.pacienteCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.pacienteCaptionTextBox.StyleName = "Caption";
            this.pacienteCaptionTextBox.Value = "paciente";
            // 
            // nombrePacienteCaptionTextBox
            // 
            this.nombrePacienteCaptionTextBox.CanGrow = true;
            this.nombrePacienteCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.033D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.nombrePacienteCaptionTextBox.Name = "nombrePacienteCaptionTextBox";
            this.nombrePacienteCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.nombrePacienteCaptionTextBox.StyleName = "Caption";
            this.nombrePacienteCaptionTextBox.Value = "Nombre Paciente";
            // 
            // productoCaptionTextBox
            // 
            this.productoCaptionTextBox.CanGrow = true;
            this.productoCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.523D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.productoCaptionTextBox.Name = "productoCaptionTextBox";
            this.productoCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.productoCaptionTextBox.StyleName = "Caption";
            this.productoCaptionTextBox.Value = "Producto";
            // 
            // descripCaptionTextBox
            // 
            this.descripCaptionTextBox.CanGrow = true;
            this.descripCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.014D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.descripCaptionTextBox.Name = "descripCaptionTextBox";
            this.descripCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.descripCaptionTextBox.StyleName = "Caption";
            this.descripCaptionTextBox.Value = "Descrip";
            // 
            // cantidadCaptionTextBox
            // 
            this.cantidadCaptionTextBox.CanGrow = true;
            this.cantidadCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.504D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.cantidadCaptionTextBox.Name = "cantidadCaptionTextBox";
            this.cantidadCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.cantidadCaptionTextBox.StyleName = "Caption";
            this.cantidadCaptionTextBox.Value = "Cantidad";
            // 
            // importeCaptionTextBox
            // 
            this.importeCaptionTextBox.CanGrow = true;
            this.importeCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.994D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.importeCaptionTextBox.Name = "importeCaptionTextBox";
            this.importeCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.importeCaptionTextBox.StyleName = "Caption";
            this.importeCaptionTextBox.Value = "Importe";
            // 
            // ventaGroupHeaderSection
            // 
            this.ventaGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.ventaGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1});
            this.ventaGroupHeaderSection.Name = "ventaGroupHeaderSection";
            // 
            // ventaGroupFooterSection
            // 
            this.ventaGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.ventaGroupFooterSection.Name = "ventaGroupFooterSection";
            // 
            // pacienteGroupHeaderSection
            // 
            this.pacienteGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.pacienteGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2});
            this.pacienteGroupHeaderSection.Name = "pacienteGroupHeaderSection";
            // 
            // pacienteGroupFooterSection
            // 
            this.pacienteGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.pacienteGroupFooterSection.Name = "pacienteGroupFooterSection";
            // 
            // nombrePacienteGroupHeaderSection
            // 
            this.nombrePacienteGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.nombrePacienteGroupHeaderSection.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3});
            this.nombrePacienteGroupHeaderSection.Name = "nombrePacienteGroupHeaderSection";
            // 
            // nombrePacienteGroupFooterSection
            // 
            this.nombrePacienteGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.nombrePacienteGroupFooterSection.Name = "nombrePacienteGroupFooterSection";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.053D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox1.StyleName = "Data";
            this.textBox1.Value = "= Fields.venta";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.543D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox2.StyleName = "Data";
            this.textBox2.Value = "= Fields.paciente";
            // 
            // textBox3
            // 
            this.textBox3.CanGrow = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.033D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.textBox3.StyleName = "Data";
            this.textBox3.Value = "= Fields.NombrePaciente";
            // 
            // pageHeader
            // 
            this.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.pageHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.reportNameTextBox});
            this.pageHeader.Name = "pageHeader";
            // 
            // reportNameTextBox
            // 
            this.reportNameTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.053D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.reportNameTextBox.Name = "reportNameTextBox";
            this.reportNameTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.378D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.reportNameTextBox.StyleName = "PageInfo";
            this.reportNameTextBox.Value = "Report1";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.053D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.663D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.769D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.663D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(2.053D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0D), Telerik.Reporting.Drawing.Unit.Cm(0D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.484D), Telerik.Reporting.Drawing.Unit.Cm(2D));
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Report1";
            // 
            // reportFooter
            // 
            this.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.reportFooter.Name = "reportFooter";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.714D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.descripDataTextBox,
            this.cantidadDataTextBox,
            this.importeDataTextBox,
            this.productoDataTextBox});
            this.detail.Name = "detail";
            // 
            // productoDataTextBox
            // 
            this.productoDataTextBox.CanGrow = true;
            this.productoDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.523D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.productoDataTextBox.Name = "productoDataTextBox";
            this.productoDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.productoDataTextBox.StyleName = "Data";
            this.productoDataTextBox.Value = "= Fields.Producto";
            // 
            // descripDataTextBox
            // 
            this.descripDataTextBox.CanGrow = true;
            this.descripDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.014D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.descripDataTextBox.Name = "descripDataTextBox";
            this.descripDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.descripDataTextBox.StyleName = "Data";
            this.descripDataTextBox.Value = "= Fields.Descrip";
            // 
            // cantidadDataTextBox
            // 
            this.cantidadDataTextBox.CanGrow = true;
            this.cantidadDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.504D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.cantidadDataTextBox.Name = "cantidadDataTextBox";
            this.cantidadDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.cantidadDataTextBox.StyleName = "Data";
            this.cantidadDataTextBox.Value = "= Fields.Cantidad";
            // 
            // importeDataTextBox
            // 
            this.importeDataTextBox.CanGrow = true;
            this.importeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.994D), Telerik.Reporting.Drawing.Unit.Cm(0.053D));
            this.importeDataTextBox.Name = "importeDataTextBox";
            this.importeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.437D), Telerik.Reporting.Drawing.Unit.Cm(0.6D));
            this.importeDataTextBox.StyleName = "Data";
            this.importeDataTextBox.Value = "= Fields.Importe";
            // 
            // Report1
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.labelsGroupFooterSection;
            group1.GroupHeader = this.labelsGroupHeaderSection;
            group1.Name = "labelsGroup";
            group2.GroupFooter = this.ventaGroupFooterSection;
            group2.GroupHeader = this.ventaGroupHeaderSection;
            group2.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.venta"));
            group2.Name = "ventaGroup";
            group3.GroupFooter = this.pacienteGroupFooterSection;
            group3.GroupHeader = this.pacienteGroupHeaderSection;
            group3.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.paciente"));
            group3.Name = "pacienteGroup";
            group4.GroupFooter = this.nombrePacienteGroupFooterSection;
            group4.GroupHeader = this.nombrePacienteGroupHeaderSection;
            group4.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.NombrePaciente"));
            group4.Name = "nombrePacienteGroup";
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1,
            group2,
            group3,
            group4});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.labelsGroupHeaderSection,
            this.labelsGroupFooterSection,
            this.ventaGroupHeaderSection,
            this.ventaGroupFooterSection,
            this.pacienteGroupHeaderSection,
            this.pacienteGroupFooterSection,
            this.nombrePacienteGroupHeaderSection,
            this.nombrePacienteGroupFooterSection,
            this.pageHeader,
            this.pageFooter,
            this.reportHeader,
            this.reportFooter,
            this.detail});
            this.Name = "Report1";
            this.PageSettings.ContinuousPaper = false;
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Mm(20D), Telerik.Reporting.Drawing.Unit.Mm(20D), Telerik.Reporting.Drawing.Unit.Mm(20D), Telerik.Reporting.Drawing.Unit.Mm(20D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "FechaIni";
            reportParameter1.Text = "FechaIni";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime;
            reportParameter2.Name = "Producto";
            reportParameter2.Text = "Producto";
            reportParameter3.Name = "Cliente";
            reportParameter3.Text = "Cliente";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Bold = true;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule5.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule5.Style.Font.Name = "Tahoma";
            styleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4,
            styleRule5});
            this.Width = Telerik.Reporting.Drawing.Unit.Cm(17.484D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.SqlDataSource sqlDataSource1;
        private Telerik.Reporting.GroupHeaderSection labelsGroupHeaderSection;
        private Telerik.Reporting.TextBox ventaCaptionTextBox;
        private Telerik.Reporting.TextBox pacienteCaptionTextBox;
        private Telerik.Reporting.TextBox nombrePacienteCaptionTextBox;
        private Telerik.Reporting.TextBox productoCaptionTextBox;
        private Telerik.Reporting.TextBox descripCaptionTextBox;
        private Telerik.Reporting.TextBox cantidadCaptionTextBox;
        private Telerik.Reporting.TextBox importeCaptionTextBox;
        private Telerik.Reporting.GroupFooterSection labelsGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection ventaGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.GroupFooterSection ventaGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection pacienteGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.GroupFooterSection pacienteGroupFooterSection;
        private Telerik.Reporting.GroupHeaderSection nombrePacienteGroupHeaderSection;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.GroupFooterSection nombrePacienteGroupFooterSection;
        private Telerik.Reporting.PageHeaderSection pageHeader;
        private Telerik.Reporting.TextBox reportNameTextBox;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.ReportFooterSection reportFooter;
        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox productoDataTextBox;
        private Telerik.Reporting.TextBox descripDataTextBox;
        private Telerik.Reporting.TextBox cantidadDataTextBox;
        private Telerik.Reporting.TextBox importeDataTextBox;
    }
}