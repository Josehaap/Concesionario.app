using System;
using System.Runtime.CompilerServices;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace LibsClass;

public class Coche
{

    #region Propiedades privadas
    private string? _marca;
    private string? _modelo;
    private int _anio;
    private double? _velocidadMaxima;
    private string? _descripcion;
    private TiposCombustibles _combustible;
    #endregion

    #region Variables necesarias path, etc
    const string path = "wwwroot/data/img";
    string PathCarpeta = "";
    #endregion

    [Required(ErrorMessage = "La marca es obligatoria.")]
    public string Marca
    {
        //Si llegase a ser nulo le damos un valor por defecto que no pase la validación de abajo
        get => _marca ?? "";
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("La marca no puede estar vacía.");
            _marca = value;
        }
    }

    [Required(ErrorMessage = "El modelo es obligatoria.")]
    public string Modelo
    {
        get => _modelo ?? "";
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El modelo no puede estar vacío.");
            _modelo = value;
        }
    }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    public string Descripcion
    {
        get => _descripcion ?? "";
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("la descripcion no puede estar vacío");
            _descripcion = value;
        }
    }

    /// <summary>
    /// Propiedad que declara el año de fabricación teniendo en cuenta que ciertos coches antiguos no se pueden vender ya 
    /// </summary>
    public int AnioFabricacion
    {
        get { return _anio; }
        set
        {
            int anioActual = DateTime.Now.Year;
            if (value < 1886 || value > anioActual)
                throw new ArgumentOutOfRangeException($"El año debe estar entre 1886 y {anioActual}.");
            _anio = value;
        }
    }

    /// <summary>
    /// Propiedad que podremos indicar la velocidad punta, en caso de que este fuera nul podremos pr defecto una velocidad generica 120. 
    /// </summary>
    public double? VelocidadMaxima
    {
        get { return _velocidadMaxima; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException("La velocidad máxima debe ser mayor que 0.");
            _velocidadMaxima = value ?? 120;
        }
    }

    public TiposCombustibles Combustible
    {
        get => _combustible;

        set => _combustible = value;
    }

    /// <summary>
    /// Array donde se guardará las imágenes de cada vehiculo 
    /// </summary>
    public List<string> ListadoPathDeImagenes = [];

    public Coche(string marca, string modelo, string descripcion, int anioFabricacion, TiposCombustibles combustible, double? velocidadMaxima = null, string? nombre_img = null)
    {
        _marca = marca;
        _modelo = modelo;
        _descripcion = descripcion;
        _anio = anioFabricacion;
        _velocidadMaxima = velocidadMaxima;
        _combustible = combustible;
        CrearDirectorioImg();
        AsociarImagenes(nombre_img);
    }

    /// <summary>
    /// Metodo de inistancia que se llamará en el constructor creando en este un carpeta predeterminada
    /// donde se guardará las imágenes de dicho coche. 
    /// </summary>
    private void CrearDirectorioImg()
    {
        PathCarpeta = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/data/img", $"{Marca}_{Modelo}");
       
        if (!Directory.Exists(PathCarpeta))
        {
            Directory.CreateDirectory(PathCarpeta);
        }
        
    }

    /// <summary>
    /// Metodo privado para crear la estructura de las rutas de las imagenes de cada coche 
    /// </summary>
    /// <param name="nombreArchivo"></param>
    /// <returns></returns>

    private string FormarRutaCompletaImg(string nombreArchivo)
    {
        if (string.IsNullOrWhiteSpace(nombreArchivo))
        {
            throw new ArgumentException("El nombre del archivo no puede ser nulo o vacío.");
        }

        return Path.Combine($"data/img/{Marca}_{Modelo}", nombreArchivo);
    }

    public void AsociarImagenes( string? nombre = null, List<string>? listadoNombre = null)
    {
        if (listadoNombre is not null)
        {
            ListadoPathDeImagenes = listadoNombre.Select(FormarRutaCompletaImg).ToList();
        }
        else if (!string.IsNullOrWhiteSpace(nombre))
        {
            ListadoPathDeImagenes.Add(FormarRutaCompletaImg(nombre));
        }

    }

  



}






