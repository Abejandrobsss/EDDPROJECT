using System;
using System.Collections;
using System.IO;

namespace EDD
{
    class BaseDeDatosLocal
    {
        
        public static void guardarLista(ArrayList lista, string archivo)
        {
            string writeText = ""; //contenido a escribir
            for (int i = 0; i < lista.Count; i++)
            {
                switch (archivo)
                {
                    case "Alumnos.txt":
                        Alumno tmp1 = (Alumno)lista[i];
                        writeText += tmp1.IDAlumno + "," + tmp1.NombreAlumno + "," + tmp1.ApellidoPaterno + "," + tmp1.ApellidoMaterno + "," + tmp1.DiaDeNacimiento + "," + tmp1.Semestre + "\n";
                        break;

                    case "Materias.txt":
                        Materias tmp2 = (Materias)lista[i];
                        writeText += tmp2.IDMateria + "," + tmp2.NombreMateria +"\n";
                        break;

                    case "MPA.txt":
                        MateriasPorAlumno tmp3 = (MateriasPorAlumno)lista[i];
                        writeText += tmp3.IDAsoc+ "," + tmp3.IDAlumno + "," + tmp3.IDMateria + "," + tmp3.Calificacion +"\n";
                        break;
                    }
                    
                }
            
            //escribe el texto en el archivo
            File.WriteAllText(@"Archivos\" + archivo, writeText);
        }

        public static ArrayList recuperarLista(string archivo)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Archivos\" + archivo);

            ArrayList lista = new ArrayList();
            for (int i = 0; i < lines.Length; i++)
            {
                switch (archivo)
                {
                    case "Alumnos.txt":
                        Alumno alumno = new Alumno();
                        string[] linea1th = lines[i].Split(",");
                        alumno.IDAlumno= linea1th[0];
                        alumno.NombreAlumno = linea1th[1];
                        alumno.ApellidoPaterno = linea1th[2];
                        alumno.ApellidoMaterno = linea1th[3];
                        alumno.DiaDeNacimiento = linea1th[4];
                        alumno.Semestre = Convert.ToInt32(linea1th[5]);
                        lista.Add(alumno);
                        break;

                    case "Materias.txt":
                        Materias materias = new Materias();
                        string[] linea2nd = lines[i].Split(",");
                        materias.IDMateria= linea2nd[0];
                        materias.NombreMateria = linea2nd[1];
                        lista.Add(materias);
                        break;

                    case "MPA.txt":
                        MateriasPorAlumno MPA = new MateriasPorAlumno();
                        string[] linea3rd = lines[i].Split(",");
                        MPA.IDAsoc = linea3rd[0];
                        MPA.IDAlumno = linea3rd[1];
                        MPA.IDMateria = linea3rd[2];
                        MPA.Calificacion = Convert.ToDouble(linea3rd[3]);
                        lista.Add(MPA);
                        break;
                }
            }

            //devolver lista generada
            return lista;

        }
    }
}
