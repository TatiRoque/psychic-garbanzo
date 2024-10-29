﻿using System;
using System.Runtime.Serialization.Formatters;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Linq;

namespace TrabajoIntegrador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30);
            EstablecerColores();
            CentrarYMostrarMensaje();
            RestaurarColores();
            Console.ReadKey();
            string nombre = ConsultarNombre();
            List<Cancion> Canciones = new List<Cancion>();
            bool existeCancion = false;
            Menu(nombre, Canciones, existeCancion);
        }
        static void EstablecerColores()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;  
            Console.ForegroundColor = ConsoleColor.Yellow;    
        }
        static void CentrarYMostrarMensaje()
        {
            int anchoConsola = Console.WindowWidth;
            int altoConsola = Console.WindowHeight;

            int anchoRecuadro = 50;
            int altoRecuadro = 10;

            int posicionX = (anchoConsola - anchoRecuadro) / 2;
            int posicionY = (altoConsola - altoRecuadro) / 2;

            DibujarBorde(anchoRecuadro, altoRecuadro, posicionX, posicionY);

            
            string mensaje = " Bienvenido a MusiConsola ";
            int posicionMensajeX = posicionX + (anchoRecuadro - mensaje.Length) / 2;
            int posicionMensajeY = posicionY + altoRecuadro / 2;

            Console.SetCursorPosition(posicionMensajeX, posicionMensajeY);
            Console.WriteLine(mensaje);
        }
        static void DibujarBorde(int ancho, int alto, int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write("╔");
            for (int i = 0; i < ancho - 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            for (int i = 1; i < alto - 1; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.Write("║");
                Console.SetCursorPosition(posX + ancho - 1, posY + i);
                Console.Write("║");
            }
            Console.SetCursorPosition(posX, posY + alto - 1);
            Console.Write("╚");
            for (int i = 0; i < ancho - 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
        }
        static void RestaurarColores()
        {
            Console.ResetColor();
        }
        static string ConsultarNombre()
        {
            string nombre;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("¿Cómo es tu nombre?\n\n");
                nombre = Console.ReadLine();

               
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("\nPor favor ingrese un nombre para continuar.");
                    Console.WriteLine("Presione cualquier tecla para intentar de nuevo...");
                    Console.ReadKey();
                }
                else
                {
                    break;
                }
            }

            return nombre;
        }

        static void Menu(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            while (true) // Bucle para seguir mostrando el menú hasta que se elija salir
            {
                Console.Clear();
                Console.Write("Bienvenido al menú ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(nombre);
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Elija la opción que quiera ejecutar\n\n");
                Console.WriteLine("1. Teoría Musical.\n");
                Console.WriteLine("2. Escalas.\n");
                Console.WriteLine("3. Guardar mis canciones.\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("4. Salir. \n\n\n");
                Console.ResetColor();

                string input = Console.ReadLine();
                int opcion;

                // validar la entrada
                bool isValidInput = int.TryParse(input, out opcion);
                if (!isValidInput || opcion < 1 || opcion > 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEntrada inválida. Por favor, elija una opción válida (1 - 4).");
                    Console.ResetColor();
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue; // vuelve al inicio del bucle para mostrar el menú nuevamente
                }

                switch (opcion)
                {
                    case 1:
                        TeoriaMusical(nombre, Canciones, existeCancion);
                        break;
                    case 2:
                        Escalas(nombre, Canciones, existeCancion);
                        break;
                    case 3:
                        GuardarAcordes(nombre, Canciones, existeCancion);
                        break;
                    case 4:
                        return;
                }
            }
        }


        static int calificacionExamen1 = -1; // -1 indica q el examen no fue realizado aun
        static int calificacionExamen2 = -1;
        static int calificacionExamen3 = -1;
        static void TeoriaMusical(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();

            Console.Clear();
            Console.WriteLine("Bienvenido al curso básico de teoría musical. Este consta de 3 módulos de aprendizaje y sus correspondientes exámenes orientados a comprobar el entendimiento de los contenidos dados. \n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Acceda a los módulos escribiendo el número indicado.\n");
            Console.ResetColor();
            Console.WriteLine("1 – Modulo I: ¿Que sería la música? \n\n2 – Modulo II: Elementos musicales \n\n3 – Modulo III: Escalas\n ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("De la misma forma puede acceder a los exámenes.\n");
            Console.ResetColor();
            Console.WriteLine("4 – Examen Módulo I \n\n5 - Examen Módulo II \n\n6 - Examen Módulo III \n\n");

            Console.WriteLine($"Calificación examen 1: {(calificacionExamen1 == -1 ? "no realizado" : calificacionExamen1.ToString())}");
            Console.WriteLine($"Calificación examen 2: {(calificacionExamen2 == -1 ? "no realizado" : calificacionExamen2.ToString())}");
            Console.WriteLine($"Calificación examen 3: {(calificacionExamen3 == -1 ? "no realizado" : calificacionExamen3.ToString())}");

            Console.WriteLine("\n\n7 - Volver al menú \n ");

            if (!int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrada no válida. Intente nuevamente. (Presione enter para volver a intentar)");
                Console.ResetColor();
                Console.ReadKey();
                TeoriaMusical(nombre, Canciones, existeCancion);

            }

            switch (opcion)
            {
                case 1:
                case 2:
                case 3:
                    mostrarModulo(opcion, nombre, Canciones, existeCancion);
                    break;

                case 4:
                    examenTM1(nombre, Canciones, existeCancion);
                    break;

                case 5:
                    examenTM2(nombre, Canciones, existeCancion);
                    break;

                case 6:
                    examenTM3(nombre, Canciones, existeCancion);
                    break;

                case 7:
                    Menu(nombre, Canciones, existeCancion);
                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El número ingresado no corresponde a una opción válida. (Presione una tecla para volver al menú)");
                    Console.ResetColor();
                    Console.ReadKey();
                    TeoriaMusical(nombre, Canciones, existeCancion);
                    break;
            }



        }

        static void mostrarModulo(int numeroModulo, string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            string[] paginas;

            switch (numeroModulo)
            {
                case 1:
                    paginas = new string[]
                    {
                        "Aristóteles: \"La música es un arte imitativo de la realidad que afecta profundamente las emociones.\" \n \nAl igual que el filósofo, muchas personas a lo largo de la historia se aventuraron a la dicha misión de poder \nmediante definiciones, limitar las posibilidades del concepto, a fin de controlarlo o quizá sentirlo de alguna \nmanera, concretable. \n\nEl material teórico a continuación se centrará en este último campo mencionado, lo concreto, de forma que se evitaran posibles y probables ambigüedades. \n",
                        "La música se define como una organización de sonidos que produce efectos en el oyente. \n\nDesde la antigüedad, la música ha sido una parte integral de la cultura humana, utilizada en rituales, ceremonias y como forma de entretenimiento. \n\nA través de diversas civilizaciones, la música ha evolucionado y se ha adaptado a diferentes contextos sociales y culturales. \n",
                        "La música no solo se experimenta de manera auditiva, sino que también puede provocar respuestas emocionales profundas. \n\nLos ritmos y melodías pueden evocar recuerdos y sentimientos, conectando a las personas a través de experiencias compartidas. \n\nAsí, la música se convierte en un lenguaje universal que trasciende fronteras. \n",
                        "A lo largo del tiempo, diferentes teorías musicales han surgido para explicar cómo se percibe y se crea la música. \n\nDesde la teoría de las proporciones de Pitágoras hasta la armonía moderna, cada enfoque ha buscado desentrañar los secretos detrás de la creación musical. \n\nLa música, en este sentido, es tanto un arte como una ciencia. \n",
                        "El papel del compositor es crucial en la creación musical, ya que es quien da forma a las ideas y las traduce en sonidos. \n\nLos compositores utilizan diferentes técnicas y estilos para expresar su visión artística. \n\nDesde la notación musical hasta la improvisación, cada método ofrece una manera única de comunicar emociones. \n",
                        "Los intérpretes, por su parte, aportan su propia interpretación a las obras musicales, convirtiéndose en mediadores entre el compositor y el público. \n\nLa actuación musical implica no solo la ejecución técnica, sino también la capacidad de transmitir el sentimiento detrás de la música. \n\nEsto agrega otra capa de significado a la experiencia musical. \n",
                        "A medida que la música ha evolucionado, también lo han hecho los instrumentos musicales. \n\nDesde los primitivos instrumentos de percusión hasta los sofisticados sintetizadores de hoy, cada instrumento aporta su timbre y textura únicos a la música. \n\nLa elección de instrumentos influye directamente en el carácter de una composición. \n",
                        "La teoría musical no solo se ocupa de la composición, sino también de la forma en que los elementos musicales se combinan. \n\nConceptos como melodía, armonía y ritmo son fundamentales para entender cómo se construyen las obras musicales. \n\nCada uno de estos elementos juega un papel vital en la creación de una experiencia auditiva cohesiva. \n",
                        "La práctica de la música en conjunto, o la música de cámara, permite a los músicos interactuar y colaborar, enriqueciendo la experiencia musical. \n\nEste tipo de interpretación fomenta la comunicación y la creatividad, haciendo que la música sea una experiencia compartida. \n\nEl trabajo en equipo es esencial para lograr una interpretación exitosa. \n",
                        "La música, como arte, también refleja la sociedad y la cultura en la que se crea. \n\nA través de las diferentes épocas, los estilos musicales han sido un reflejo de los cambios sociales, políticos y culturales. \n\nAsí, la música se convierte en un espejo de la humanidad, capturando su esencia a lo largo de la historia. \n"
                        };
                    break;
                case 2:
                    paginas = new string[]
                    {
                        "En el ámbito de la teoría musical, la polifonía es un concepto clave. \n\nSe refiere a la simultaneidad de varias líneas melódicas independientes, creando una textura rica y compleja. \n\nEste estilo se encuentra en muchas tradiciones musicales alrededor del mundo. \n",
                        "La forma musical describe la estructura de una composición. \n\nConceptos como verso-coro y sonata son ejemplos de formas utilizadas para organizar las ideas musicales. \n\nComprender la forma es esencial para la creación y análisis musical. \n",
                        "La textura musical se refiere a cómo se combinan las distintas voces e instrumentos en una pieza. \n\nDesde la monofonía hasta la polifonía, cada tipo de textura ofrece una experiencia auditiva única. \n\nLa textura puede influir en la percepción y el impacto emocional de la música. \n",
                        "La dinámica en música se refiere a las variaciones en el volumen de las notas. \n\nLos contrastes dinámicos pueden añadir drama y emoción a una interpretación, destacando momentos clave en una composición. \n\nLa habilidad de manejar la dinámica es vital para los intérpretes. \n",
                        "La ornamentación es el uso de adornos melódicos para enriquecer una línea musical. \n\nEste recurso puede hacer que una melodía suene más expresiva y elaborada. \n\nLos músicos pueden aplicar diversas técnicas de ornamentación para personalizar su interpretación. \n",
                        "El análisis musical es una herramienta esencial para comprender y descomponer las obras. \n\nA través del análisis, los músicos pueden identificar patrones, estructuras y elementos que contribuyen al efecto general de la música. \n\nEsta habilidad es invaluable para la educación musical. \n",
                        "La improvisación es una forma de expresión creativa que permite a los músicos crear música en el momento. \n\nEste arte requiere un profundo conocimiento de la teoría y la técnica musical. \n\nLa improvisación también fomenta la creatividad y la espontaneidad. \n",
                        "El ritmo es uno de los elementos más fundamentales de la música. \n\nLos patrones rítmicos no solo estructuran la música, sino que también pueden evocar emociones y energías específicas. \n\nLa variación en el ritmo puede transformar completamente una composición. \n",
                        "La interpretación musical es el proceso a través del cual un músico da vida a una obra. \n\nCada intérprete aporta su propio estilo y sensibilidad, haciendo que incluso la misma"
                    };
                    break;
                case 3:
                    paginas = new string[]
                    {
                        "La música occidental está compuesta por 12 notas que se repiten en distintos registros, \n" +
                        "lo que significa que puedes encontrar las mismas notas más altas o más bajas. \n" +
                        "Estas notas son: Do, Do#, Re, Re#, Mi, Fa, Fa#, Sol, Sol#, La, La# y Si. \n\n" +
                        "En las escalas y canciones, también verás los nombres de estas notas \n" +
                        "en su versión sin sostenidos (Do, Re, Mi, Fa, Sol, La, Si). \n",

                        "¿Qué es un tono y un semitono? \n\n" +
                        "Para entender cómo construir escalas, necesitamos conocer la distancia entre dos notas, \n" +
                        "conocida como *intervalo*. Un *semitono* es la distancia más corta entre dos notas consecutivas, \n" +
                        "por ejemplo, entre Do y Do# o entre Mi y Fa. \n\n" +
                        "Un *tono* equivale a dos semitonos, como la distancia entre Do y Re o entre La y Si. \n" +
                        "Estos intervalos de tono y semitono son esenciales para construir escalas. \n",

                        "Escala Mayor \n\n" +
                        "La escala mayor es una secuencia de notas que produce un sonido alegre y brillante. \n" +
                        "Para construirla, seguimos un patrón fijo de tonos y semitonos: \n" +
                        "Tono, Tono, Semitono, Tono, Tono, Tono, Semitono. \n" +
                        "Este patrón es el mismo sin importar en qué nota comencemos. \n\n" +
                        "Por ejemplo, para construir la escala de Do mayor, seguimos este patrón: \n" +
                        "- Do - Re (tono) \n" +
                        "- Re - Mi (tono) \n" +
                        "- Mi - Fa (semitono) \n" +
                        "- Fa - Sol (tono) \n" +
                        "- Sol - La (tono) \n" +
                        "- La - Si (tono) \n" +
                        "- Si - Do (semitono) \n\n" +
                        "Esto nos da la escala de Do mayor: Do, Re, Mi, Fa, Sol, La, Si, Do. \n",

                        "Escala Menor \n\n" +
                        "La escala menor se usa para transmitir emociones más melancólicas o profundas. \n" +
                        "El patrón de la escala menor es: \n" +
                        "Tono, Semitono, Tono, Tono, Semitono, Tono, Tono. \n\n" +
                        "Sigamos este patrón para construir la escala de La menor: \n" +
                        "- La - Si (tono) \n" +
                        "- Si - Do (semitono) \n" +
                        "- Do - Re (tono) \n" +
                        "- Re - Mi (tono) \n" +
                        "- Mi - Fa (semitono) \n" +
                        "- Fa - Sol (tono) \n" +
                        "- Sol - La (tono) \n\n" +
                        "Esto nos da la escala de La menor: La, Si, Do, Re, Mi, Fa, Sol, La. \n",

                        "Con estos patrones, puedes construir tanto escalas mayores como menores en cualquier nota de inicio. \n" +
                        "Las escalas son fundamentales para comprender la estructura de las canciones y la relación entre las notas. \n" +
                        "También te permiten crear y entender melodías y armonías básicas. \n"

                    };
                    break;
                default:
                    paginas = new string[0];
                    break;
            }
            NavegarPaginas(numeroModulo, paginas, nombre, Canciones, existeCancion);
        }

        static void NavegarPaginas(int numeroModulo, string[] paginas, string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            int paginaActual = 0;
            bool enLectura = true;

            while (enLectura)
            {
                // mostrar encabezado
                Console.Clear();
                Console.WriteLine($"Modulo {numeroModulo}  /  Página {paginaActual + 1}\n\n\n");
                Console.WriteLine(paginas[paginaActual]);

                // mostrar pie de página
                Console.SetCursorPosition(0, 28);
                Console.WriteLine("(Utiliza las flechas izquierda y derecha para navegar el texto, presiona enter para volver al menu de teoria musical)");

                // capturar la tecla
                var tecla = Console.ReadKey().Key;

                switch (tecla)
                {
                    case ConsoleKey.RightArrow:
                        if (paginaActual < paginas.Length - 1)
                        {
                            paginaActual++;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (paginaActual > 0)
                        {
                            paginaActual--;
                        }
                        break;

                    case ConsoleKey.Enter:
                        enLectura = false;
                        TeoriaMusical(nombre, Canciones, existeCancion);
                        break;
                }
            }
            TeoriaMusical(nombre, Canciones, existeCancion);
        }

        static void examenTM1(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();
            int correctas = 0;

            string[] preguntas =
            {
                "1. Aristóteles definió la música como un arte imitativo de la realidad. (V/F)",
                "2. La música ha sido utilizada únicamente como entretenimiento. (V/F)",
                "3. Los compositores son responsables de dar forma a las ideas musicales. (V/F)",
                "4. La interpretación musical no requiere de habilidades técnicas. (V/F)",
                "5. Los instrumentos musicales no han evolucionado con el tiempo. (V/F)"
            };
            for (int i = 0; i < preguntas.Length; i++)
            {
                Console.Clear();
                Console.Write("Eliga ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Verdadero (V)");
                Console.ResetColor();
                Console.Write(" o ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Falso (F)\n");
                Console.ResetColor();
                Console.WriteLine(preguntas[i]);
                string respuesta;

                // validar respuesta
                while (true)
                {
                    respuesta = Console.ReadLine().ToUpper();
                    if (respuesta == "V" || respuesta == "F")
                    {
                        break;
                    }
                    Console.WriteLine("Respuesta no válida. Por favor ingrese 'V' o 'F'.");
                }

                // se registran respuestas correctas
                if ((i == 0 && respuesta == "V") ||
                    (i == 1 && respuesta == "F") ||
                    (i == 2 && respuesta == "V") ||
                    (i == 3 && respuesta == "F") ||
                    (i == 4 && respuesta == "F"))
                {
                    correctas++;
                }
            }

            // calcular la calificación del 1 al 10
            calificacionExamen1 = (int)Math.Round((correctas / 5.0) * 10);
            Console.Clear();
            Console.WriteLine($"Examen completado. Su calificación es: {calificacionExamen1}/10. Presione una tecla para continuar...");
            Console.ReadKey();
            TeoriaMusical(nombre, Canciones, existeCancion);
        }

        static void examenTM2(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();
            int correctas = 0;

            string[] preguntas =
            {
                "1. La polifonía se refiere a varias líneas melódicas independientes. (V/F)",
                "2. La forma musical describe la estructura de una composición. (V/F)",
                "3. La dinámica en música se refiere a las variaciones en el volumen de las notas. (V/F)",
                "4. La ornamentación se utiliza para simplificar una línea musical. (V/F)",
                "5. El ritmo es uno de los elementos más fundamentales de la música. (V/F)"
            };

            for (int i = 0; i < preguntas.Length; i++)
            {
                Console.Clear();
                Console.WriteLine(preguntas[i]);
                string respuesta;


                while (true)
                {
                    respuesta = Console.ReadLine().ToUpper();
                    if (respuesta == "V" || respuesta == "F")
                    {
                        break;
                    }
                    Console.WriteLine("Respuesta no válida. Por favor ingrese 'V' o 'F'.");
                }


                if ((i == 0 && respuesta == "V") ||
                    (i == 1 && respuesta == "F") ||
                    (i == 2 && respuesta == "V") ||
                    (i == 3 && respuesta == "F") ||
                    (i == 4 && respuesta == "V"))
                {
                    correctas++;
                }
            }

            calificacionExamen2 = (int)Math.Round((correctas / 5.0) * 10);
            Console.Clear();
            Console.WriteLine($"Examen completado. Su calificación es: {calificacionExamen2}/10. Presione una tecla para continuar...");
            Console.ReadKey();
            TeoriaMusical(nombre, Canciones, existeCancion);
        }

        static void examenTM3(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();
            int correctas = 0;

            string[] preguntas =
            {
                "1. La polifonía se refiere a varias líneas melódicas independientes. (V/F)",
                "2. La forma musical describe la estructura de una composición. (V/F)",
                "3. La dinámica en música se refiere a las variaciones en el volumen de las notas. (V/F)",
                "4. La ornamentación se utiliza para simplificar una línea musical. (V/F)",
                "5. La improvisación es una forma de expresión creativa que permite a los músicos crear música en el momento. (V/F)"
            };

            for (int i = 0; i < preguntas.Length; i++)
            {
                Console.Clear();
                Console.WriteLine(preguntas[i]);
                string respuesta;


                while (true)
                {
                    respuesta = Console.ReadLine().ToUpper();
                    if (respuesta == "V" || respuesta == "F")
                    {
                        break;
                    }
                    Console.WriteLine("Respuesta no válida. Por favor ingrese 'V' o 'F'.");
                }


                if ((i == 0 && respuesta == "V") ||
                    (i == 1 && respuesta == "V") ||
                    (i == 2 && respuesta == "V") ||
                    (i == 3 && respuesta == "F") ||
                    (i == 4 && respuesta == "V"))
                {
                    correctas++;
                }
            }

            calificacionExamen3 = (int)Math.Round((correctas / 5.0) * 10);
            Console.Clear();
            Console.WriteLine($"Examen completado. Su calificación es: {calificacionExamen3}/10. Presione una tecla para continuar...");
            Console.ReadKey();
            TeoriaMusical(nombre, Canciones, existeCancion);
        }

        static void Escalas(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();
            Console.Write($"Por favor eliga una opcion ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(nombre);
            Console.ResetColor();
            Console.WriteLine("\n1. Mostrar las escalas mayores.\n");
            Console.WriteLine("2. Mostrar las escalas menores.\n");
            Console.WriteLine("3. Consultar por la escala mayor de una nota.\n");
            Console.WriteLine("4. Consultar por la escala menor de una nota.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5. Volver al menú.\n\n");
            Console.ResetColor();
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    MostrarEscalasMayores(nombre, Canciones, existeCancion);
                    break;
                case 2:
                    MostrarEscalasMenores(nombre, Canciones, existeCancion);
                    break;
                case 3:
                    ConsultaEscalaMayor(nombre, Canciones, existeCancion);
                    break;
                case 4:
                    ConsultaEscalaMenor(nombre, Canciones, existeCancion);
                    break;
                case 5:
                    Menu(nombre, Canciones, existeCancion);
                    break;
            }
        }
        static void MostrarEscalasMayores(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();

            string[,] EscalaMayor = { { "C", "D", "E", "F", "G", "A", "B", "C" },
                { "D", "E", "F#", "G", "A", "B", "C#", "D" },
                { "E", "F#", "G#", "A", "B", "C#", "D#", "E" },
                { "F", "G", "A", "Bb", "C", "D", "E", "F" },
            { "G", "A", "B", "C", "D", "E", "F#", "G" },
                { "A", "B", "C#", "D", "E", "F#", "G#", "A" },
                { "B", "C#", "D#", "E", "F#", "G#", "A#", "B" } };
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("╔════════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╗");
                Console.Write("║");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("  \t");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{EscalaMayor[i, j]}");
                    Console.ResetColor();
                    Console.Write("\t ║ ");

                }
                Console.WriteLine();
                Console.WriteLine("╚════════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╝");
            }
            MenuEscalas(nombre, Canciones, existeCancion);
        }
        static void MostrarEscalasMenores(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();
            string[,] EscalaMenor = { { "C", "D", "Eb", "F", "G", "Ab", "Bb", "C" }, { "D", "E", "F", "G", "A", "Bb", "C", "D" }, { "E", "F#", "G", "A", "B", "C", "D", "E" }, { "F", "G", "Ab", "Bb", "C", "Db", "Eb", "F" }, { "G", "A", "B", "C", "D", "E", "F#", "G" }, { "A", "Bb", "C", "D", "Eb", "F", "G", "A" }, { "B", "C#", "D", "E", "F#", "G#", "A", "B" } };
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("╔════════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╗");
                Console.Write("║");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("  \t");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{EscalaMenor[i, j]}");
                    Console.ResetColor();
                    Console.Write("\t ║ ");
                }
                Console.WriteLine();
                Console.WriteLine("╚════════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╝");
            }
            MenuEscalas(nombre, Canciones, existeCancion);
        }
        static void ConsultaEscalaMayor(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();
            Console.WriteLine("Ingrese una nota para saber su escala mayor (A, B, C, D, E, F, G): ");
            string nota = Console.ReadLine().ToUpper();
            if (!NotaValida(nota))
            {
                Console.WriteLine("Nota inválida. Por favor ingrese una nota válida.");
                return;
            }

            string[] escalaMayor = ObtenerEscalaMayor(nota);
            Console.Clear();
            Console.WriteLine($"La escala mayor de {nota} es: ");
            Console.WriteLine("╔════════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╗");
            Console.Write("║");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("  \t");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{escalaMayor[i]}");
                Console.ResetColor();
                Console.Write("\t ║ ");

            }
            Console.WriteLine();
            Console.WriteLine("╚════════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╝");
            MenuEscalas(nombre, Canciones, existeCancion);
        }
        static bool NotaValida(string nota)
        {
            string[] notasValidas = { "A", "B", "C", "D", "E", "F", "G" };
            return Array.Exists(notasValidas, n => n == nota);
        }
        static string[] ObtenerEscalaMayor(string notaBase)
        {
            string[] escalaCromatica = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

            int indiceNotaBase = Array.IndexOf(escalaCromatica, notaBase);

            // Tono, Tono, Semitono, Tono, Tono, Tono, Semitono
            int[] intervalos = { 2, 2, 1, 2, 2, 2, 1 };

            string[] escalaMayor = new string[8];

            // La primera posición del array escalaMayor será siempre la nota base ingresada por el usuario.
            escalaMayor[0] = notaBase;

            // Calcular las demás notas de la escala mayor
            int indiceActual = indiceNotaBase;
            for (int i = 0; i < intervalos.Length; i++)
            {
                // Si el índice calculado es 12, entonces 12 % 12 = 0 (volver a la primera nota, C).
                //Si el índice calculado es 13, entonces 13 % 12 = 1(volvemos a la segunda nota, C#).
                indiceActual = (indiceActual + intervalos[i]) % escalaCromatica.Length;
                escalaMayor[i + 1] = escalaCromatica[indiceActual];
            }

            return escalaMayor;
        }
        static void ConsultaEscalaMenor(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();
            Console.WriteLine("Ingrese una nota para saber su escala menor (A, B, C, D, E, F, G): ");
            string nota = Console.ReadLine().ToUpper();
            string eEscalaMenor = "E";
            string bEscalaMenor = "B";
            if (nota == eEscalaMenor || nota == bEscalaMenor)
            {
                string[] escalaMenor = EscalaMenorEyB(nota);
                Console.Clear();
                Console.WriteLine($"La escala menor de {nota} es: ");
                Console.WriteLine("╔════════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╗");
                Console.Write("║");
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("  \t");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{escalaMenor[i]}");
                    Console.ResetColor();
                    Console.Write("\t ║ ");

                }
                Console.WriteLine();
                Console.WriteLine("╚════════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╝");
                MenuEscalas(nombre, Canciones, existeCancion);
            }
            if (!EsNotaValida(nota))
            {
                Console.WriteLine("Nota inválida. Por favor ingrese una nota válida.");
                return;
            }
            else
            {
                string[] escalaMenor = ObtenerEscalaMenor(nota);
                Console.Clear();
                Console.WriteLine($"La escala menor de {nota} es: ");
                Console.WriteLine("╔════════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╦═══════════════╗");
                Console.Write("║");
                for (int i = 0; i < 8; i++)
                {
                    Console.Write("  \t");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{escalaMenor[i]}");
                    Console.ResetColor();
                    Console.Write("\t ║ ");
                }
                Console.WriteLine();
                Console.WriteLine("╚════════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╩═══════════════╝");
                MenuEscalas(nombre, Canciones, existeCancion);
            }
        }
        static bool EsNotaValida(string nota)
        {
            string[] notasValidas = { "A", "B", "C", "D", "E", "F", "G" };
            return Array.Exists(notasValidas, n => n == nota);
        }
        static string[] EscalaMenorEyB(string notaBase)
        {
            string[] escalaCromatica = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };

            int indiceNotaBase = Array.IndexOf(escalaCromatica, notaBase);

            // Tono, Tono, Semitono, Tono, Tono, Tono, Semitono
            int[] intervalos = { 2, 1, 2, 2, 1, 2, 2 };

            string[] escalaMenor = new string[8];

            // La primera posición del array escalaMayor será siempre la nota base ingresada por el usuario.
            escalaMenor[0] = notaBase;

            // Calcular las demás notas de la escala mayor
            int indiceActual = indiceNotaBase;
            for (int i = 0; i < intervalos.Length; i++)
            {
                // Si el índice calculado es 12, entonces 12 % 12 = 0 (volver a la primera nota, C).
                //Si el índice calculado es 13, entonces 13 % 12 = 1(volvemos a la segunda nota, C#).
                indiceActual = (indiceActual + intervalos[i]) % escalaCromatica.Length;
                escalaMenor[i + 1] = escalaCromatica[indiceActual];
            }
            return escalaMenor;
        }
        static string[] ObtenerEscalaMenor(string notaBase)
        {
            string[] escalaCromatica = { "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab", "A", "Bb", "B" };

            int indiceNotaBase = Array.IndexOf(escalaCromatica, notaBase);

            // Tono - Semitono - Tono - Tono - Semitono - Tono - Tono
            int[] intervalos = { 2, 1, 2, 2, 1, 2, 2 };

            string[] escalaMenor = new string[8];

            // La primera posición del array escalaMayor será siempre la nota base ingresada por el usuario.
            escalaMenor[0] = notaBase;

            // Calcular las demás notas de la escala mayor
            int indiceActual = indiceNotaBase;
            for (int i = 0; i < intervalos.Length; i++)
            {
                // Si el índice calculado es 12, entonces 12 % 12 = 0 (volver a la primera nota, C).
                //Si el índice calculado es 13, entonces 13 % 12 = 1(volvemos a la segunda nota, C#).
                indiceActual = (indiceActual + intervalos[i]) % escalaCromatica.Length;
                escalaMenor[i + 1] = escalaCromatica[indiceActual];
            }

            return escalaMenor;
        }

        static void MenuEscalas(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(nombre);
            Console.ResetColor();
            Console.WriteLine(", selecciona una opción\n");
            Console.WriteLine("1. Volver al menú de escalas.\n");
            Console.WriteLine("2. Volver al menú principal.\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ResetColor();

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Escalas(nombre, Canciones, existeCancion);
                        break;
                    case 2:
                        Menu(nombre, Canciones, existeCancion);
                        break;
                    default:
                        Console.Clear();
                        MenuEscalas(nombre, Canciones, existeCancion);
                        break;
                }
            }
            else
            {
                Console.Clear();
                MenuEscalas(nombre, Canciones, existeCancion);
            }
        }

        static void GuardarAcordes(string nombre, List<Cancion> Canciones, bool existeCancion)
        {

            MenuAcordes(nombre, Canciones, existeCancion);
        }
        static void MenuAcordes(string nombre, List<Cancion> Canciones, bool existeCancion)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(nombre);
            Console.ResetColor();
            Console.WriteLine(", selecciona una opción\n\n");
            Console.WriteLine("1. Agregar canción\n");
            Console.WriteLine("2. Mostrar todas las canciones\n");
            Console.WriteLine("3. Buscar canciones\n");
            Console.WriteLine("4. Agregar o borrar un acorde \n");
            Console.WriteLine("5. Borrar canción\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("6. Volver al menú principal\n\n\n");
            Console.ResetColor();
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    AgregarCancion(Canciones, nombre, existeCancion);
                    break;
                case 2:
                    MostrarCanciones(Canciones, nombre, existeCancion);
                    break;
                case 3:
                    BuscarCancion(Canciones, nombre, existeCancion);
                    break;
                case 4:
                    OpcionMenuAcordes(Canciones, nombre, existeCancion);
                    break;
                case 5:
                    BorrarCancion(Canciones, nombre, existeCancion);
                    break;
                case 6:
                    Menu(nombre, Canciones, existeCancion);
                    break;

            }
        }
        static void OpcionMenuAcordes(List<Cancion> Canciones, string nombre, bool existeCancion)
        {
            if (existeCancion = false)
            {
                Console.WriteLine("No hay ninguna canción gurdada");
                AgregarCancion(Canciones, nombre, existeCancion);
            }
            else
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(nombre);
                Console.ResetColor();
                Console.Write(" deseas agregar un acorde o borrarlo? ( ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("A");
                Console.ResetColor();
                Console.Write(" / ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("B");
                Console.ResetColor();
                Console.WriteLine(" ), para volver al menú escriba 'salir'.");
                Console.WriteLine();
                string sb = Console.ReadLine();
                if (sb.ToLower() == "a")
                {
                    AgregarAcorde(Canciones, nombre, existeCancion);
                }
                else if (sb.ToLower() == "b")
                {
                    BorrarAcorde(Canciones, nombre, existeCancion);
                }
                else if (sb.ToLower() == "salir")
                {
                    MenuAcordes(nombre, Canciones, existeCancion);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Por favor ingrese una opción valida");
                    Console.ResetColor();
                    Console.WriteLine(" (Presione enter para volver al menú)");
                    Console.ReadKey();
                    OpcionMenuAcordes(Canciones, nombre, existeCancion);
                }
            }


        }
        struct Cancion
        {
            public string nombre { get; set; }
            public List<string> acorde { get; set; }
            public Cancion(string nombre1)
            {
                nombre = nombre1;
                acorde = new List<string>();
            }
        }
        static void AgregarCancion(List<Cancion> Canciones, string nombre, bool existeCancion)
        {
            Console.Clear();
            Console.WriteLine("¿Cómo se llama su canción?\n");
            string nombre1 = Console.ReadLine();
            Cancion nuevaCancion = new Cancion(nombre1);
            Console.WriteLine("\nIngrese tantos acordes quiera y a al terminar escriba 'listo'.\n");
            while (true)
            {
                string acorde = Console.ReadLine();
                if (acorde.ToLower() == "listo")
                {
                    break;
                }
                nuevaCancion.acorde.Add(acorde);
            }
            Canciones.Add(nuevaCancion);
            MenuAcordes(nombre, Canciones, existeCancion);
            existeCancion = true;
        }
        static void MostrarCanciones(List<Cancion> Canciones, string nombre, bool existeCancion)
        {
            if (existeCancion = false)
            {
                Console.WriteLine("No hay ninguna canción gurdada");
                AgregarCancion(Canciones, nombre, existeCancion);
            }
            else
            {

                Console.Clear();
                foreach (var cancion in Canciones)
                {
                    Console.WriteLine();
                    Console.Write($"{cancion.nombre} por ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(nombre);
                    Console.WriteLine("");
                    Console.ResetColor();
                    Console.WriteLine(string.Join(" | ", cancion.acorde));

                }
                Console.WriteLine("\nPresione enter para volver al menú");
                Console.ReadKey();
                MenuAcordes(nombre, Canciones, existeCancion);
            }
        }
        static void BuscarCancion(List<Cancion> Canciones, string nombre, bool existeCancion)
        {
            if (existeCancion = false)
            {
                Console.WriteLine("No hay ninguna canción");
                AgregarCancion(Canciones, nombre, existeCancion);
            }
            else
            {

                Console.Clear();
                Console.WriteLine("Ingrese el nombre de la canción y se mostraran sus acordes\n");
                string nombreCancion = Console.ReadLine();
                Cancion cancionBuscar = Canciones.Find(a => a.nombre.Equals(nombreCancion, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine("");
                Console.WriteLine(string.Join(" | ", cancionBuscar.acorde));
                Console.WriteLine();
                Console.WriteLine("Presione enter para volver al menú");
                Console.ReadKey();
                MenuAcordes(nombre, Canciones, existeCancion);
            }
        }
        static void AgregarAcorde(List<Cancion> Canciones, string nombre, bool existeCancion)
        {
            if (existeCancion = false)
            {
                Console.WriteLine("No hay ninguna canción");
                AgregarCancion(Canciones, nombre, existeCancion);
            }
            else
            {

                Console.WriteLine("\nIngrese el nombre de la canción en la que esta el acorde\n");
                string nombreCancion = Console.ReadLine();
                Cancion agregarAcorde = Canciones.Find(a => a.nombre.Equals(nombreCancion, StringComparison.OrdinalIgnoreCase));
                if (nombreCancion != null)
                {
                    Console.WriteLine(string.Join(" | ", agregarAcorde.acorde));
                    Console.WriteLine();
                    Console.WriteLine("\n¿Qué acorde desea agregar?\n");
                    string acorde = Console.ReadLine();
                    agregarAcorde.acorde.Add(acorde);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nEl acorde fue agregado con exitó.\n");
                    Console.ResetColor();
                    Console.WriteLine("(Presione enter para volver al menú)\n\n\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"La canción '{nombreCancion}' no fue encontrada.\n");
                    Console.ResetColor();

                    Console.WriteLine("(Presione enter para volver al menú)\n\n\n");

                }
                Console.ReadKey();
                MenuAcordes(nombre, Canciones, existeCancion);
            }
        }
        static void BorrarAcorde(List<Cancion> Canciones, string nombre, bool existeCancion)
        {
            if (existeCancion = false)
            {
                Console.WriteLine("No hay ninguna canción");
                AgregarCancion(Canciones, nombre, existeCancion);
            }
            else
            {

                Console.WriteLine("\nIngrese el nombre de la canción en la que esta el acorde\n");
                string nombreCancion = Console.ReadLine();
                Cancion cancionBuscar = Canciones.Find(a => a.nombre.Equals(nombreCancion, StringComparison.OrdinalIgnoreCase));

                if (nombreCancion != null)
                {
                    Console.WriteLine(string.Join(" | ", cancionBuscar.acorde));
                    Console.WriteLine();
                    Console.WriteLine("¿Cuál acorde quiere borrar?\n");
                    string acordeBorrar = Console.ReadLine();

                    if (cancionBuscar.acorde.Contains(acordeBorrar))
                    {
                        cancionBuscar.acorde.Remove(acordeBorrar);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\nEl acorde '{acordeBorrar}' ha sido borrado de la canción '{cancionBuscar.nombre}'.\n\n");
                        Console.ResetColor();

                        Console.WriteLine("(Presione enter para volver al menú)\n\n\n");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\nEl acorde '{acordeBorrar}' no se encuentra en la canción '{cancionBuscar.nombre}'.\n");
                        Console.ResetColor();

                        Console.WriteLine("(Presione enter para volver al menú)\n\n\n");

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"\nLa canción '{nombreCancion}' no fue encontrada.\n");
                    Console.ResetColor();

                    Console.WriteLine("(Presione enter para volver al menú)\n\n\n");

                }
                Console.ReadKey();
                MenuAcordes(nombre, Canciones, existeCancion);
            }
        }
        static void BorrarCancion(List<Cancion> Canciones, string nombre, bool existeCancion)
        {
            if (existeCancion = false)
            {
                Console.WriteLine("No hay ninguna canción");
                AgregarCancion(Canciones, nombre, existeCancion);
            }
            else
            {

                Console.Clear();
                Console.WriteLine("Ingrese el nombre de la canción que desee borrar.\n");

                string nombreCancion = Console.ReadLine();
                Cancion cancionBorrar = Canciones.Find(a => a.nombre.Equals(nombreCancion, StringComparison.OrdinalIgnoreCase));
                if (nombreCancion != null)
                {
                    Canciones.Remove(cancionBorrar);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("La canción fue eliminada con exitó.\n");
                    Console.ResetColor();

                    Console.WriteLine("(Presione enter para volver al menú)\n\n\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"La canción '{nombreCancion}' no fue encontrada.\n");
                    Console.ResetColor();
                    Console.WriteLine("(Presione enter para volver al menú)\n\n\n");
                }
                Console.ReadKey();
                MenuAcordes(nombre, Canciones, existeCancion);
            }
        }
    }
}