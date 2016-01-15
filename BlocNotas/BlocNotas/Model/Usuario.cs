namespace BlocNotas.Model
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public string Avatar { get; set; }
    }
}
