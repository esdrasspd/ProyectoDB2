namespace ProyectoDB2.Entityes
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int IdRol { get; set; }
    }
}
