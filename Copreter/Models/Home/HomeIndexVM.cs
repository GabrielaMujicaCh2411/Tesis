namespace Copreter.Models.Home
{
    public class HomeIndexVM
    {
        public int UsuariosTotales { get; internal set; }

        public int NuevasCoticaciones { get; internal set; }

        public int ObrasTerminadas { get; internal set; }

        public int ObrasEnContruccion { get; internal set; }

        public int HerramientasDisponibles { get; internal set; }

        public int HerramientasEnMantenimiento { get; internal set; }

        public int TrabajadoresDisponibles { get; internal set; }

        public int HerramientasPorDevolver { get; internal set; }

        public int HerramientasAlquiladas { get; internal set; }
        public decimal DineroEnMes { get; internal set; }
    }
}
