using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SigesivServer.Models.StoredProdecuresTypes;
using SigesivServer.Models.ViewModels;

#nullable disable

namespace SigesivServer.Models
{
    public partial class proyectoaseguradoraequipo5Context : DbContext
    {
        public proyectoaseguradoraequipo5Context()
        {
        }

        public proyectoaseguradoraequipo5Context(DbContextOptions<proyectoaseguradoraequipo5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Asegurado> Asegurados { get; set; }
        public virtual DbSet<Casosdecobertura> Casosdecoberturas { get; set; }
        public virtual DbSet<Estadospoliza> Estadospolizas { get; set; }
        public virtual DbSet<Estadosreporte> Estadosreportes { get; set; }
        public virtual DbSet<Estadosvehiculosasegurado> Estadosvehiculosasegurados { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Modelo> Modelos { get; set; }
        public virtual DbSet<Otrosinvolucrado> Otrosinvolucrados { get; set; }
        public virtual DbSet<Otrosvehiculosinvolucrado> Otrosvehiculosinvolucrados { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Polizasdeseguro> Polizasdeseguros { get; set; }
        public virtual DbSet<Reportesdeincidente> Reportesdeincidentes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Tiposdecobertura> Tiposdecoberturas { get; set; }
        public virtual DbSet<TiposdecoberturaCasosdecobertura> TiposdecoberturaCasosdecoberturas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Vehiculosasegurado> Vehiculosasegurados { get; set; }
        public virtual DbSet<ViewModel_detalleDePolizaDeConductor> poliza { get; set; }
        public virtual DbSet<CasoDeCobertura> obtenerCobertura { get; set; }
        public virtual DbSet<Models.StoredProdecuresTypes.Pago> Pago { get; set; }
        public virtual DbSet<Models.StoredProdecuresTypes.Asegurado> Asegurado { get; set; }
        public virtual DbSet<Poliza> Poliza { get; set; }
        public virtual DbSet<Models.StoredProdecuresTypes.Usuario> Usuario { get; set; }
        public virtual DbSet<VehiculoAsegurado> VehiculoAsegurado { get; set; }
        public virtual DbSet<ViewModelPreviewPolizaDeConductor> previewPolizaDeConductor { get; set; }
        public virtual DbSet<ViewModelTipoDeCobertura> tiposDeCobertura { get; set; }
        public virtual DbSet<ViewModelReporteDeIncidenteSinAjustador> reporteSinAjustador { get; set; }
        public virtual DbSet<ViewModelPersonalAjustadores> personalAjustador { get; set; }
        public virtual DbSet<ViewModelUsuarioRegistrado> usuarioRegistrado { get; set; }
        public virtual DbSet<ViewModelAseguradoConUsername> aseguradoConUsername { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                try{
                    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                    
                    optionsBuilder.UseSqlServer("workstation id=gsxinsurance.mssql.somee.com;packet size=4096;user id=aaron-77_SQLLogin_1;pwd=hardthsc51;data source=gsxinsurance.mssql.somee.com;persist security info=False;initial catalog=gsxinsurance;TrustServerCertificate=true");
                    //optionsBuilder.UseSqlServer("server=DESKTOP-A2FGC3V\\SQLEXPRESS;database=proyectoaseguradoraequipo5;Integrated Security=True;Persist Security Info=False;MultipleActiveResultSets=True;Encrypt=No;TrustServerCertificate=False;Connection Timeout=30");
                    //optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=proyectoaseguradoraequipo5;Persist Security Info=False;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                }catch(Exception ex){
                    Console.WriteLine(ex);
                }
                //Server=tcp:serveraseguradora.database.windows.net,1433;Initial Catalog=proyectoaseguradoraequipo5;Persist Security Info=False;User ID=aaron;Password=Mofos*.*;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Asegurado>(entity =>
            {
                entity.ToTable("asegurados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("celular");

                entity.Property(e => e.FechaDeNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDeNacimiento");

                entity.Property(e => e.FkUsuario).HasColumnName("fkUsuario");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.NumeroDeLicencia)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("numeroDeLicencia");

                entity.HasOne(d => d.FkUsuarioNavigation)
                    .WithMany(p => p.Asegurados)
                    .HasForeignKey(d => d.FkUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Asegurados_usuarios");
            });

            modelBuilder.Entity<Casosdecobertura>(entity =>
            {
                entity.ToTable("casosdecobertura");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Condiciones)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("condiciones");

                entity.Property(e => e.NombreDelCaso)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombreDelCaso");
            });

            modelBuilder.Entity<Estadospoliza>(entity =>
            {
                entity.ToTable("estadospolizas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasColumnName("nombreEstado");
            });

            modelBuilder.Entity<Estadosreporte>(entity =>
            {
                entity.ToTable("estadosreporte");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasColumnName("nombreEstado");
            });

            modelBuilder.Entity<Estadosvehiculosasegurado>(entity =>
            {
                entity.ToTable("estadosvehiculosasegurados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasColumnName("nombreEstado");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("marcas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Marca1).HasColumnName("marca");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("modelos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkMarca).HasColumnName("fkMarca");

                entity.Property(e => e.Modelo1)
                    .IsRequired()
                    .HasColumnName("modelo");

                entity.HasOne(d => d.FkMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.FkMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Modelos_marcas");
            });

            modelBuilder.Entity<Otrosinvolucrado>(entity =>
            {
                entity.ToTable("otrosinvolucrados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkReporte).HasColumnName("fkReporte");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.FkReporteNavigation)
                    .WithMany(p => p.Otrosinvolucrados)
                    .HasForeignKey(d => d.FkReporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_otrosInvolucrados_reportesDeSiniestro");
            });

            modelBuilder.Entity<Otrosvehiculosinvolucrado>(entity =>
            {
                entity.ToTable("otrosvehiculosinvolucrados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(100)
                    .HasColumnName("color");

                entity.Property(e => e.FkOtroInvolucrado).HasColumnName("fkOtroInvolucrado");

                entity.Property(e => e.FkReporte).HasColumnName("fkReporte");

                entity.Property(e => e.Fkmarca).HasColumnName("fkmarca");

                entity.Property(e => e.Fkmodelo).HasColumnName("fkmodelo");

                entity.Property(e => e.NumeroDePlaca)
                    .HasMaxLength(100)
                    .HasColumnName("numeroDePlaca");

                entity.HasOne(d => d.FkOtroInvolucradoNavigation)
                    .WithMany(p => p.Otrosvehiculosinvolucrados)
                    .HasForeignKey(d => d.FkOtroInvolucrado)
                    .HasConstraintName("FK_otrosVehiculosInvolucrados_otrosInvolucrados");

                entity.HasOne(d => d.FkReporteNavigation)
                    .WithMany(p => p.Otrosvehiculosinvolucrados)
                    .HasForeignKey(d => d.FkReporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_otrosVehiculosInvolucrados_reportesDeSiniestro");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("pagos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkAsegurado).HasColumnName("fkAsegurado");

                entity.Property(e => e.NumDeTarjeta).HasColumnName("numDeTarjeta");

                entity.HasOne(d => d.FkAseguradoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.FkAsegurado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pagos_Asegurados");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("personal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaDeIngreso)
                    .HasColumnType("date")
                    .HasColumnName("fechaDeIngreso");

                entity.Property(e => e.FkRol).HasColumnName("fkRol");

                entity.Property(e => e.FkUsuario).HasColumnName("fkUsuario");

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasColumnName("nombreCompleto");

                entity.HasOne(d => d.FkRolNavigation)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.FkRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_personal_roles");

                entity.HasOne(d => d.FkUsuarioNavigation)
                    .WithMany(p => p.Personals)
                    .HasForeignKey(d => d.FkUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_personal_usuarios");
            });

            modelBuilder.Entity<Polizasdeseguro>(entity =>
            {
                entity.ToTable("polizasdeseguro");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CostoTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("costoTotal");

                entity.Property(e => e.FechaDeExpiracion)
                    .HasColumnType("date")
                    .HasColumnName("fechaDeExpiracion");

                entity.Property(e => e.FechaDeInicio)
                    .HasColumnType("date")
                    .HasColumnName("fechaDeInicio");

                entity.Property(e => e.FkAsegurado).HasColumnName("fkAsegurado");

                entity.Property(e => e.FkEstado).HasColumnName("fkEstado");

                entity.Property(e => e.FkPago).HasColumnName("fkPago");

                entity.Property(e => e.FkTipoDeCobertura).HasColumnName("fkTipoDeCobertura");

                entity.Property(e => e.FkVehiculoAsegurado).HasColumnName("fkVehiculoAsegurado");

                entity.Property(e => e.NumeroDePoliza)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("numeroDePoliza");

                entity.HasOne(d => d.FkAseguradoNavigation)
                    .WithMany(p => p.Polizasdeseguros)
                    .HasForeignKey(d => d.FkAsegurado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_polizasDeSeguro_Asegurados");

                entity.HasOne(d => d.FkEstadoNavigation)
                    .WithMany(p => p.Polizasdeseguros)
                    .HasForeignKey(d => d.FkEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_polizasDeSeguro_estadosPolizas");

                entity.HasOne(d => d.FkPagoNavigation)
                    .WithMany(p => p.Polizasdeseguros)
                    .HasForeignKey(d => d.FkPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_polizasDeSeguro_Pagos");

                entity.HasOne(d => d.FkTipoDeCoberturaNavigation)
                    .WithMany(p => p.Polizasdeseguros)
                    .HasForeignKey(d => d.FkTipoDeCobertura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_polizasDeSeguro_tiposDeCobertura");

                entity.HasOne(d => d.FkVehiculoAseguradoNavigation)
                    .WithMany(p => p.Polizasdeseguros)
                    .HasForeignKey(d => d.FkVehiculoAsegurado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_polizasDeSeguro_VehiculosAsegurados");
            });

            modelBuilder.Entity<Reportesdeincidente>(entity =>
            {
                entity.ToTable("reportesdeincidente");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaDelReporte)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaDelReporte");

                entity.Property(e => e.FkAsegurado).HasColumnName("fkAsegurado");

                entity.Property(e => e.FkEstado).HasColumnName("fkEstado");

                entity.Property(e => e.FkPersonal).HasColumnName("fkPersonal");

                entity.Property(e => e.FkVehiculoAsegurado).HasColumnName("fkVehiculoAsegurado");

                entity.Property(e => e.Latitud)
                    .HasColumnType("decimal(8, 6)")
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasColumnType("decimal(8, 6)")
                    .HasColumnName("longitud");

                entity.Property(e => e.UrlImagen1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("urlImagen1");

                entity.Property(e => e.UrlImagen2)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("urlImagen2");

                entity.Property(e => e.UrlImagen3)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("urlImagen3");

                entity.Property(e => e.UrlImagen4)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("urlImagen4");

                entity.Property(e => e.UrlImagen5)
                    .HasColumnType("text")
                    .HasColumnName("urlImagen5");

                entity.Property(e => e.UrlImagen6)
                    .HasColumnType("text")
                    .HasColumnName("urlImagen6");

                entity.Property(e => e.UrlImagen7)
                    .HasColumnType("text")
                    .HasColumnName("urlImagen7");

                entity.Property(e => e.UrlImagen8)
                    .HasColumnType("text")
                    .HasColumnName("urlImagen8");

                entity.HasOne(d => d.FkAseguradoNavigation)
                    .WithMany(p => p.Reportesdeincidentes)
                    .HasForeignKey(d => d.FkAsegurado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reportesDeSiniestro_asegurados1");

                entity.HasOne(d => d.FkEstadoNavigation)
                    .WithMany(p => p.Reportesdeincidentes)
                    .HasForeignKey(d => d.FkEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reportesDeSiniestro_estadosReporte");

                entity.HasOne(d => d.FkPersonalNavigation)
                    .WithMany(p => p.Reportesdeincidentes)
                    .HasForeignKey(d => d.FkPersonal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reportesDeSiniestro_personal");

                entity.HasOne(d => d.FkVehiculoAseguradoNavigation)
                    .WithMany(p => p.Reportesdeincidentes)
                    .HasForeignKey(d => d.FkVehiculoAsegurado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_reportesDeSiniestro_VehiculosAsegurados");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Rol)
                    .IsRequired()
                    .HasColumnName("rol");
            });

            modelBuilder.Entity<Tiposdecobertura>(entity =>
            {
                entity.ToTable("tiposdecobertura");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Costo)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("costo");

                entity.Property(e => e.LapsoDeCobertura).HasColumnName("lapsoDeCobertura");

                entity.Property(e => e.TipoDeCobertura)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tipoDeCobertura");
            });

            modelBuilder.Entity<TiposdecoberturaCasosdecobertura>(entity =>
            {
                entity.ToTable("tiposdecobertura_casosdecobertura");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkCasoDeCobertura).HasColumnName("fkCasoDeCobertura");

                entity.Property(e => e.FkTipoDeCobertura).HasColumnName("fkTipoDeCobertura");

                entity.HasOne(d => d.FkCasoDeCoberturaNavigation)
                    .WithMany(p => p.TiposdecoberturaCasosdecoberturas)
                    .HasForeignKey(d => d.FkCasoDeCobertura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tiposDeCobertura_casosDeCobertura_casosdecobertura");

                entity.HasOne(d => d.FkTipoDeCoberturaNavigation)
                    .WithMany(p => p.TiposdecoberturaCasosdecoberturas)
                    .HasForeignKey(d => d.FkTipoDeCobertura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tiposDeCobertura_casosDeCobertura_tiposDeCobertura");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkRol).HasColumnName("fkRol");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username");

                entity.HasOne(d => d.FkRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.FkRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarios_roles");
            });

            modelBuilder.Entity<Vehiculosasegurado>(entity =>
            {
                entity.ToTable("vehiculosasegurados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Año).HasColumnName("año");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.FkEstado).HasColumnName("fkEstado");

                entity.Property(e => e.FkMarca).HasColumnName("fkMarca");

                entity.Property(e => e.FkModelo).HasColumnName("fkModelo");

                entity.Property(e => e.NumeroDePlacas)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("numeroDePlacas");

                entity.Property(e => e.NumeroDeSerie)
                    .IsRequired()
                    .HasColumnName("numeroDeSerie");

                entity.HasOne(d => d.FkEstadoNavigation)
                    .WithMany(p => p.Vehiculosasegurados)
                    .HasForeignKey(d => d.FkEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehiculosAsegurados_estadosVehiculosAsegurados");

                entity.HasOne(d => d.FkMarcaNavigation)
                    .WithMany(p => p.Vehiculosasegurados)
                    .HasForeignKey(d => d.FkMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehiculosAsegurados_marcas");

                entity.HasOne(d => d.FkModeloNavigation)
                    .WithMany(p => p.Vehiculosasegurados)
                    .HasForeignKey(d => d.FkModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehiculosAsegurados_Modelos");
            });
            modelBuilder.Entity<ViewModel_detalleDePolizaDeConductor>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.idAsegurado).HasColumnName("idAsegurado");
                entity.Property(e => e.fechaDeNacimiento).HasColumnName("fechaDeNacimiento");
                entity.Property(e => e.nombreCompleto).HasColumnName("nombreCompleto");
                entity.Property(e => e.numeroDeLicencia).HasColumnName("numeroDeLicencia");
                entity.Property(e => e.celular).HasColumnName("celular");
                entity.Property(e => e.idPoliza).HasColumnName("idPoliza");
                entity.Property(e => e.numeroDePoliza).HasColumnName("numeroDePoliza");
                entity.Property(e => e.fechaDeInicio).HasColumnName("fechaDeInicio");
                entity.Property(e => e.fechaDeExpiracion).HasColumnName("fechaDeExpiracion");
                entity.Property(e => e.tipoDeCobertura).HasColumnName("tipoDeCobertura");
                entity.Property(e => e.lapsoDeCobertura).HasColumnName("lapsoDeCobertura");
                entity.Property(e => e.marca).HasColumnName("marca");
                entity.Property(e => e.modelo).HasColumnName("modelo");
                entity.Property(e => e.numeroDePlacas).HasColumnName("numeroDePlacas");
                entity.Property(e => e.año).HasColumnName("año");
                entity.Property(e => e.color).HasColumnName("color");
            });

            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.costoTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("costoTotal");

                entity.Property(e => e.fechaDeExpiracion)
                    .HasColumnType("varchar")
                    .HasMaxLength(20)
                    .HasColumnName("fechaDeExpiracion");

                entity.Property(e => e.fechaDeInicio)
                    .HasColumnType("varchar")
                    .HasMaxLength(20)
                    .HasColumnName("fechaDeInicio");

                entity.Property(e => e.fkAsegurado).HasColumnName("fkAsegurado");

                entity.Property(e => e.fkEstado).HasColumnName("fkEstado");

                entity.Property(e => e.fkPago).HasColumnName("fkPago");

                entity.Property(e => e.fkTipoDeCobertura).HasColumnName("fkTipoDeCobertura");

                entity.Property(e => e.fkVehiculoAsegurado).HasColumnName("fkVehiculoAsegurado");

                entity.Property(e => e.numeroDePoliza)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("numeroDePoliza");
            });
            modelBuilder.Entity<CasoDeCobertura>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.nombreDelCaso).HasColumnName("nombreDelCaso");
                entity.Property(e => e.condiciones).HasColumnName("condiciones");
            });

            modelBuilder.Entity<Models.StoredProdecuresTypes.Pago>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.fkAsegurado).HasColumnName("fkAsegurado");
                entity.Property(e => e.numDeTarjeta).HasColumnName("numDeTarjeta");

            });

            modelBuilder.Entity<Models.StoredProdecuresTypes.VehiculoAsegurado>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.ano).HasColumnName("año");

                entity.Property(e => e.color)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.fkEstado).HasColumnName("fkEstado");

                entity.Property(e => e.fkMarca).HasColumnName("fkMarca");

                entity.Property(e => e.fkModelo).HasColumnName("fkModelo");

                entity.Property(e => e.numeroDePlacas)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("numeroDePlacas");

                entity.Property(e => e.numeroDeSerie)
                    .IsRequired()
                    .HasColumnName("numeroDeSerie");

            });

            modelBuilder.Entity<Models.StoredProdecuresTypes.Usuario>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.fkRol).HasColumnName("fkRol");

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.username)
                    .IsRequired()
                    .HasColumnName("username");

            });

            modelBuilder.Entity<Models.StoredProdecuresTypes.Asegurado>(entity =>
            {

                entity.HasNoKey();
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.celular)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("celular");

                entity.Property(e => e.fechaDeNacimiento)
                    .HasMaxLength(20)
                    .HasColumnName("fechaDeNacimiento");

                entity.Property(e => e.fkUsuario).HasColumnName("fkUsuario");

                entity.Property(e => e.nombreCompleto)
                    .IsRequired()
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.numeroDeLicencia)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("numeroDeLicencia");
            });

            modelBuilder.Entity<Models.ViewModels.ViewModelReporteDeIncidentePreview>(entity =>
            {

                entity.HasNoKey();
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.nombreCompleto)
                    .HasColumnName("nombreCompleto");

                entity.Property(e => e.marca).HasColumnName("marca");

                entity.Property(e => e.modelo)
                    .HasColumnName("modelo");

                entity.Property(e => e.color)
                    .HasColumnName("color");

                entity.Property(e => e.url1)
                    .HasColumnName("urlImagen1");

                entity.Property(e => e.url2)
                    .HasColumnName("urlImagen2");

                entity.Property(e => e.url3)
                    .HasColumnName("urlImagen3");

                entity.Property(e => e.url4)
                    .HasColumnName("urlImagen4");

                entity.Property(e => e.url5)
                    .HasColumnName("urlImagen5");

                entity.Property(e => e.url6)
                    .HasColumnName("urlImagen6");

                entity.Property(e => e.url7)
                    .HasColumnName("urlImagen7");

                entity.Property(e => e.url8)
                    .HasColumnName("urlImagen8");

            });

            modelBuilder.Entity<Models.StoredProdecuresTypes.ReporteDeIncidente>(entity =>
            {

                entity.HasNoKey();
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.fkAsegurado)
                    .HasColumnName("fkAsegurado");

                entity.Property(e => e.fkVehiculoAsegurado).HasColumnName("fkVehiculoAsegurado");

                entity.Property(e => e.fkPersonal)
                    .HasColumnName("fkPersonal");

                entity.Property(e => e.latitud)
                    .HasColumnName("latitud");

                entity.Property(e => e.longitud)
                    .HasColumnName("longitud");

                entity.Property(e => e.urlImagen1)
                    .HasColumnName("urlImagen1");

                entity.Property(e => e.urlImagen2)
                    .HasColumnName("urlImagen2");

                entity.Property(e => e.urlImagen3)
                    .HasColumnName("urlImagen3");

                entity.Property(e => e.urlImagen4)
                    .HasColumnName("urlImagen4");

                entity.Property(e => e.urlImagen5)
                    .HasColumnName("urlImagen5");

                entity.Property(e => e.urlImagen6)
                    .HasColumnName("urlImagen6");

                entity.Property(e => e.urlImagen7)
                    .HasColumnName("urlImagen7");

                entity.Property(e => e.urlImagen8)
                    .HasColumnName("urlImagen8");

                entity.Property(e => e.fkEstado)
                    .HasColumnName("fkEstado");

                entity.Property(e => e.fechaDelReporte)
                    .HasColumnName("fechaDelReporte");

            });

            modelBuilder.Entity<Models.StoredProdecuresTypes.OtroInvolucrado>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.nombre)
                    .HasColumnName("nombre");

                entity.Property(e => e.fkReporte)
                    .HasColumnName("fkReporte");
   
            });

            modelBuilder.Entity<Models.StoredProdecuresTypes.OtroVehiculoInvolucrado>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.fkOtroInvolucrado)
                    .HasColumnName("fkOtroInvolucrado");

                entity.Property(e => e.fkmarca)
                    .HasColumnName("fkmarca");

                entity.Property(e => e.fkmodelo).HasColumnName("fkmodelo");

                entity.Property(e => e.color)
                    .HasColumnName("color");

                entity.Property(e => e.numeroDePlaca)
                    .HasColumnName("numeroDePlaca");

                entity.Property(e => e.fkReporte)
                    .HasColumnName("fkReporte");
            });

            modelBuilder.Entity<Models.ViewModels.ViewModelPreviewPolizaDeConductor>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.numeroDePoliza).HasColumnName("numeroDePoliza");

                entity.Property(e => e.modelo)
                    .HasColumnName("modelo");

                entity.Property(e => e.fechaDeInicio)
                    .HasColumnName("fechaDeInicio");

                entity.Property(e => e.fechaDeExpiracion).HasColumnName("fechaDeExpiracion");

                entity.Property(e => e.estado)
                    .HasColumnName("nombreEstado");

                entity.Property(e => e.fkVehiculoAsegurado)
                    .HasColumnName("fkVehiculoAsegurado");
            });

            modelBuilder.Entity<Models.ViewModels.ViewModelTipoDeCobertura>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.tipoDeCobertura).HasColumnName("tipoDeCobertura");

                entity.Property(e => e.lapsoDeCobertura)
                    .HasColumnName("lapsoDeCobertura");

                entity.Property(e => e.costo)
                    .HasColumnName("costo");
               
            });

            modelBuilder.Entity<Models.ViewModels.ViewModelReporteDeIncidenteSinAjustador>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.fkAsegurado).HasColumnName("fkAsegurado");

                entity.Property(e => e.fkVehiculoAsegurado).HasColumnName("fkVehiculoAsegurado");

                entity.Property(e => e.fkPersonal).HasColumnName("fkPersonal");

                entity.Property(e => e.latitud).HasColumnName("latitud");

                entity.Property(e => e.longitud).HasColumnName("longitud");

                entity.Property(e => e.urlImagen1).HasColumnName("urlImagen1");

                entity.Property(e => e.urlImagen2).HasColumnName("urlImagen2");

                entity.Property(e => e.urlImagen3).HasColumnName("urlImagen3");

                entity.Property(e => e.urlImagen4).HasColumnName("urlImagen4");

                entity.Property(e => e.urlImagen5).HasColumnName("urlImagen5");

                entity.Property(e => e.urlImagen6).HasColumnName("urlImagen6");

                entity.Property(e => e.urlImagen7).HasColumnName("urlImagen7");

                entity.Property(e => e.urlImagen8).HasColumnName("urlImagen8");

                entity.Property(e => e.fkEstado).HasColumnName("fkEstado");

                entity.Property(e => e.fechaDelReporte).HasColumnName("fechaDelReporte");
            });

            modelBuilder.Entity< Models.ViewModels.ViewModelPersonalAjustadores> (entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.fkUsuario).HasColumnName("fkUsuario");

                entity.Property(e => e.fkRol).HasColumnName("fkRol");

                entity.Property(e => e.nombreCompleto).IsRequired().HasColumnName("nombreCompleto");

                entity.Property(e => e.fechaDeIngreso).HasColumnName("fechaDeIngreso");
            });

            modelBuilder.Entity<Models.ViewModels.ViewModelUsuarioRegistrado>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.fkRol).HasColumnName("fkRol");

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.username)
                    .IsRequired()
                    .HasColumnName("username");

            });

            modelBuilder.Entity<Models.ViewModels.ViewModelAseguradoConUsername>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.nombreCompleto).HasColumnName("nombreCompleto");

                entity.Property(e => e.fkUsuario)
                    .IsRequired()
                    .HasColumnName("fkUsuario");

                entity.Property(e => e.username)
                    .IsRequired()
                    .HasColumnName("username");

                entity.Property(e => e.fkRol).HasColumnName("fkRol");

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
