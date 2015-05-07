using Modelo.EN;
using System;

namespace Web.Desarrollo
{
    public partial class IniciarBD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerarClientes();
            GenerarVideojuegos();
            GenerarAdministradores();
            GenerarConsolas();
            GenerarPerifericos();
        }

        private void GenerarClientes()
        {
            var cliente = new ClienteEN();
            cliente.BorrarTodos();
            cliente = new ClienteEN("manu", "manu@manu.com", "manuel", "no quiero decir mi direccion");
            cliente.Guardar();
            cliente = new ClienteEN("ana", "ana@ana.com", "anamaria", "por donde la lonja");
            cliente.Guardar();
            cliente = new ClienteEN("andres", "andres@andres.com", "andresprimo", "por ahí por altabix");
            cliente.Guardar();
        }

        private void GenerarVideojuegos()
        {
            var v = new VideojuegoEN();
            v.BorrarTodos();
            v = new VideojuegoEN("Grand Theft Auto V", 59.99, 100, 18,
                " Un joven estafador callejero, un ladrón de bancos retirado y un psicópata " +
                "aterrador tendrán que llevar a cabo una serie de peligrosos golpes para" + 
                " sobrevivir en una ciudad implacable en la que no pueden confiar en nadie." + 
                " Y mucho menos los unos en los otros.");
            v.Guardar();

            v = new VideojuegoEN("DARK SOULS™ II: Scholar of the First Sin", 39.99, 100, 16,
                "Scholar of the First Sin lleva la característica oscuridad de la franquicia y" + 
                " su apasionante jugabilidad a un nuevo nivel. Únete al oscuro viaje y experimenta" + 
                " los sobrecogedores encuentros con enemigos, los peligros diabólicos y los desafíos implacables.");
            v.Guardar();

            v = new VideojuegoEN("Just Cause™ 3", 49.99, 100, 18,
                "Explora más de 1000 km2, desde los cielos hasta los fondos marinos, " + 
                " y usa todo tipo de armas, artefactos y vehículos para desatar el caos " + 
                "de las formas más creativas y explosivas imaginables.");
            v.Guardar();

            v = new VideojuegoEN("Project CARS", 49.99, 100, 3,
                "¡Project CARS ofrece la máxima emoción al volante!");
            v.Guardar();

            v = new VideojuegoEN("Wolfenstein: The Old Blood", 19.99, 100, 18, 
                "Wolfenstein®: The Old Blood es una precuela independiente del aclamado " + 
                " shooter de acción en primera persona Wolfenstein®: The New Order. La aventura, " + 
                "que abarca ocho capítulos y dos historias interconectadas, contiene " + 
                "los sellos de MachineGames: acción apasionante, una historia.");
            v.Guardar();

            v = new VideojuegoEN("Truck Mechanic Simulator 2015", 19.99, 100, 3,
                "¡Prepárate para los grandes! Este impresionante simulador te pone en la piel del " + 
                "propietario de un taller de coches especializado en camiones. ¡Con más de 100" + 
                " piezas interactivas por camión, este detallado juego no es para pesos ligeros!");
            v.Guardar();

        }

        private void GenerarAdministradores()
        {
            var admin = new AdministradorEN();
            admin.BorrarTodos();
            admin = new AdministradorEN("admin", "admin");
            admin.Guardar();
        }

        private void GenerarConsolas()
        {
            var c = new ConsolaEN();
            c.Borrartodos();
            c.Nombre = "Nintendo - Wii Mini Roja y Negra";
            c.Precio = 99;
            c.CantidadStock = 100;
            c.Descripcion = "Wii Mini, el último modelo de consola más asequible y" + 
                " ligero del momento. El nuevo diseño que te ofrece Nintendo es el de " +
                "una Wii convencional, pero que disfrutarás al máximo al poder" + 
                " llevártela allí donde quieras. Su reducido tamaño y los nuevos " + 
                "colores, harán que tengas que hacerte ya con ella";
            c.Guardar();

            c.Nombre = "Sony - PS4 Negra Básica, 500Gb";
            c.Precio = 375;
            c.CantidadStock = 100;
            c.Descripcion = "La consola PS4 ha sido diseñada para que goces" + 
                " de una amplia gama de juegos con gráficos detallados de alta" + 
                " definición y vivas una experiencia que romperá todas tus expectativas." + 
                " Gracias a los procesadores ultrarrápidos y la memoria unificada" + 
                " de alto rendimiento de 8GB, disfrutarás como nunca antes hayas" + 
                " visto de los mejores juegos. (Incluye un mando inalámbrico).";
            c.Guardar();
        }

        private void GenerarPerifericos()
        {
            var p = new PerifericoEN();
            p.BorrarTodos();
            p.Nombre = " Logitech B100 Ratón negro";
            p.Precio = 7.95;
            p.CantidadStock = 100;
            p.Descripcion = "Cómodo, diseño ambidiestro La forma cómoda" + 
                " y de bajo perfil se siente bien en cualquier mano, incluso después" + 
                " de un largo día de trabajo. 800 dpi precisión óptica Disfrutará suave," + 
                " control preciso del cursor que permite editar documentos y navegar" + 
                " por la Web de manera más eficiente." + 
                " Configuración Zero Funciona nada más sacarlo de la caja, basta conectarla" 
                + " al puerto USB y ya está listo para los negocios.";
            p.Guardar();

            p.Nombre = "Natec Baribal Gaming Headset";
            p.Precio = 24.95;
            p.CantidadStock = 100;
            p.Descripcion = "Modernos y cómodos auriculares de diseño que permitirán al usuario" + 
                " conseguir la mejor calidad de sonido con la máxima comodidad. Cascos acolchados" + 
                " con auriculares de símil piel de máxima calidad y comodidad." + 
                " Calidad de sonido excepcional.Transmisión nítida de la voz." + 
                " Cascos con diadema ajustable. Varilla giratoria rigida para colocar el micrófono" + 
                " donde desee. Control de volumen integrado en el cable";
            p.Guardar();

            p.Nombre = "B-Move Set Free Kit Teclado y Ratón Wireless";
            p.Precio = 19.90;
            p.CantidadStock = 100;
            p.Descripcion = "*Elegante diseño ultra-delgado: 286 * 121 * 19mm." + 
                " Teclas de función multimedia. Mecanismo de alta calidad suave y silencioso." + 
                " Tecnología 2.4G inalámbrica con alcance de 10m y nano-receptor.";
            p.Guardar();
        }
    }
}