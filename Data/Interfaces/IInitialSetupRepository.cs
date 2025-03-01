namespace Sopromil.Data.Interfaces
{
    public interface IInitialSetupRepository
    {
        Task<string> VerificarUsuariosAsync();
        Task<string> CrearUsuarioInicialAsync(string nombre, string login, string password);
        Task<string> CrearEmpresaAsync(string nombre, string ruc, string direccion, string telefono, string correo, string moneda, byte[] logo);
        Task<string> ConfiguracionInicialAsync(string agradecimiento, string anuncio, string datosFiscales, string copiaSeguridad, string impresora, string lectorCodigoBarras);
    }
}
