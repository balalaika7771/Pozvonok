using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApplicationMove3DModel
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };
    class Mypoint
    {
        public Mypoint()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        public float x = 0;
        public float y = 0;
        public float z = 0;
       
        public Mypoint(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    class plot
    {
       public Mypoint[] p = new Mypoint[4];
       public plot(Mypoint a, Mypoint b, Mypoint c, Mypoint d)
        {
            p[0] = a;
            p[1] = b;
            p[2] = c;
            p[3] = d;
        }

        Mypoint center()
        {
            float x = p[1].x + p[2].x + p[3].x + p[0].x;
            x = x / 4;
            float y = p[1].y + p[2].y + p[3].y + p[0].y;
            y = y / 4;
            float z = p[1].z + p[2].z + p[3].z + p[0].z;
            z = z / 4;
            return new Mypoint(x, y, z);
        }
        public float maxX()
        {
            float max = p[0].x - center().x;
            for(int i = 0;i < 4; i++)
            {
                if(max < p[i].x - center().x)
                {
                    max = p[i].x - center().x;
                }
            }
            return max;
        }
        public float maxY()
        {
            float max = p[0].y - center().y;
            for (int i = 0; i < 4; i++)
            {
                if (max < p[i].y - center().y)
                {
                    max = p[i].y - center().y;
                }
            }
            return max;
        }
        public float maxZ()
        {
            float max = p[0].z - center().z;
            for (int i = 0; i < 4; i++)
            {
                if (max < p[i].z - center().z)
                {
                    max = p[i].z - center().z;
                }
            }
            return max;
        }

    }

    
    class pozvonok
    {
        List<string> file = new List<string>();
        int k = 1;
        Mypoint center(plot pl)
        {
            float x = pl.p[1].x + pl.p[2].x + pl.p[3].x + pl.p[0].x;
            x = x / 4;
            float y = pl.p[1].y+ pl.p[2].y + pl.p[3].y + pl.p[0].y;
            y = y / 4;
            float z = pl.p[1].z + pl.p[2].z + pl.p[3].z + pl.p[0].z;
            z = z / 4;
            return new Mypoint(x, y, z);
        }
        void Load_cylinder( plot plot1, plot plot2)
        {
            List<Mypoint> circle1 = new List<Mypoint>();
            List<Mypoint> circle2 = new List<Mypoint>();

            Mypoint center1 = center(plot1);
            Mypoint center2 = center(plot2);
            float angle = (float)-3.14 ;
            while (angle < 3.14)
            {
                float x, y, z;
                x = center1.x + ((plot1.maxX()) * (float)1.5 * (float)Math.Cos(angle));
                y = center1.y + ((plot1.maxY()) * (float)1.5 * -(float)Math.Cos(angle));
                z = center1.z + ((plot1.maxZ()) * (float)1.5 * (float)Math.Sin(angle));
                circle1.Add(new Mypoint(x, y, z));
                angle = angle + (float)0.4;
            }

            angle = (float)-3.14;
            while (angle < 3.14)
            {
                float x, y, z;
                x = center2.x + ((plot2.maxX()) * (float)1.5 * (float)Math.Cos(angle));
                y = center2.y + ((plot2.maxY()) * (float)1.5 * -(float)Math.Cos(angle));
                z = center2.z + ((plot2.maxZ()) * (float)1.5 * (float)Math.Sin(angle));
                circle2.Add(new Mypoint(x, y, z));
                angle = angle + (float)0.4;
            }
            
            for (int i = 0; i < circle1.Count; i++)
            {
                if (i == circle1.Count - 1)
                {
                    file.Add("v "+ Math.Round(circle1[i].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle1[0].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[0].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[0].z, 1).ToString().Replace(',', '.'));
                }
                else
                {
                    file.Add("v " + Math.Round(circle1[i].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle1[i+1].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i+1].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i+1].z, 1).ToString().Replace(',', '.'));
                }
                file.Add("v " + Math.Round(center1.x, 1).ToString().Replace(',', '.') + " " + Math.Round(center1.y, 1).ToString().Replace(',', '.') + " " + Math.Round(center1.z, 1).ToString().Replace(',', '.'));

                file.Add("f " +  k++.ToString() + " " + k++.ToString() + " " + k++.ToString() );
            }

            for (int i = 0; i < circle2.Count; i++)
            {
                if (i == circle2.Count - 1)
                {
                    file.Add("v " + Math.Round(circle2[i].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle2[0].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[0].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[0].z, 1).ToString().Replace(',', '.'));
                }
                else
                {
                    file.Add("v " + Math.Round(circle2[i].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle2[i + 1].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i + 1].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i + 1].z, 1).ToString().Replace(',', '.'));
                }
                file.Add("v " + center2.x.ToString().Replace(',', '.') + " " + center2.y.ToString().Replace(',', '.') + " " + center2.z.ToString().Replace(',', '.'));
                file.Add("f " + k++.ToString() + " " + k++.ToString() + " " + k++.ToString() );
            }

            for (int i = 0; i < circle1.Count; i++)
            {
                if (i == circle1.Count - 1)
                {
                    file.Add("v " + Math.Round(circle1[i].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle1[0].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[0].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[0].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle2[0].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[0].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[0].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle2[i].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i].z, 1).ToString().Replace(',', '.'));
                }
                else
                {
                    file.Add("v " + Math.Round(circle1[i + 1].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i + 1].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i + 1].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle1[i].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle1[i].z, 1).ToString().Replace(',', '.'));

                    file.Add("v " + Math.Round(circle2[i].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(circle2[i + 1].x, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i + 1].y, 1).ToString().Replace(',', '.') + " " + Math.Round(circle2[i + 1].z, 1).ToString().Replace(',', '.'));
                }
                file.Add("f " + k++.ToString() + " " + k++.ToString() + " " + k++.ToString() + " " + k++.ToString() );
            }
        }

        void Load_plot( plot plot1, plot plot2)
        {
                    file.Add("v " + Math.Round(plot1.p[0].x, 1).ToString().Replace(',', '.') + " " + Math.Round(plot1.p[0].y, 1).ToString().Replace(',', '.') + " " + Math.Round(plot1.p[0].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(plot1.p[1].x, 1).ToString().Replace(',', '.') + " " + Math.Round(plot1.p[1].y, 1).ToString().Replace(',', '.') + " " + Math.Round(plot1.p[1].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(plot1.p[2].x, 1).ToString().Replace(',', '.') + " " + Math.Round(plot1.p[2].y, 1).ToString().Replace(',', '.') + " " + Math.Round(plot1.p[2].z, 1).ToString().Replace(',', '.'));
                    file.Add("v " + Math.Round(plot1.p[3].x, 1).ToString().Replace(',', '.') + " " + Math.Round(plot1.p[3].y, 1).ToString().Replace(',', '.') + " " + Math.Round(plot1.p[3].z, 1).ToString().Replace(',', '.'));
            file.Add("f " + k++.ToString() + " " + k++.ToString() + " " + k++.ToString() + " " + k++.ToString());
            file.Add("v " + Math.Round(plot2.p[0].x, 1).ToString().Replace(',', '.') + " " + Math.Round(plot2.p[0].y, 1).ToString().Replace(',', '.') + " " + Math.Round(plot2.p[0].z, 1).ToString().Replace(',', '.'));
            file.Add("v " + Math.Round(plot2.p[1].x, 1).ToString().Replace(',', '.') + " " + Math.Round(plot2.p[1].y, 1).ToString().Replace(',', '.') + " " + Math.Round(plot2.p[1].z, 1).ToString().Replace(',', '.'));
            file.Add("v " + Math.Round(plot2.p[2].x, 1).ToString().Replace(',', '.') + " " + Math.Round(plot2.p[2].y, 1).ToString().Replace(',', '.') + " " + Math.Round(plot2.p[2].z, 1).ToString().Replace(',', '.'));
            file.Add("v " + Math.Round(plot2.p[3].x, 1).ToString().Replace(',', '.') + " " + Math.Round(plot2.p[3].y, 1).ToString().Replace(',', '.') + " " + Math.Round(plot2.p[3].z, 1).ToString().Replace(',', '.'));
            file.Add("f " + k++.ToString() + " " + k++.ToString() + " " + k++.ToString() + " " + k++.ToString());

            


        }

        public string generateObjFile(string path)
        {
            var V = new List<KeyValuePair<plot, plot>>();
            string[] lines = File.ReadAllLines(path);
            
            for(int i = 0; i < lines.Length;)
            {
                string line = lines[i++];
                
                if (line.Length > 0 &&( line[0] == 'C' || line[0] == 'T' || line[0] == 'L' || line[0] == 'S'))
                {
                    Mypoint[] Pr = new Mypoint[4];
                    for(int j = 0;j < 4; j++)
                    {
                        line = lines[i++];
                        string[] subs = line.Split('\t', ' ');
                        List<string> Lsmv = new List<string>();
                        
                        for (int k = 0; k < subs.Length; k++)
                        {
                            if (!string.IsNullOrWhiteSpace(subs[k]))
                            {
                                Lsmv.Add(subs[k]);
                            }
                        }
                        string[] smv = Lsmv.ToArray();
                        for (int k = 0; k < smv.Length; k++)
                            {
                                smv[k] = smv[k].Replace('.', ',');
                            }

                        Pr[j] = new Mypoint(float.Parse(smv[0]), float.Parse(smv[1]), float.Parse(smv[2]));
                      
                    }
                    V.Add(new KeyValuePair<plot, plot> (new plot(
                    new Mypoint(Pr[0].x, Pr[0].y, (Pr[0].z + Pr[3].z) / 2),
                    new Mypoint((Pr[0].x + Pr[3].x) / 2, (Pr[0].y + Pr[3].y) / 2, Pr[0].z),
                    new Mypoint(Pr[3].x, Pr[3].y, (Pr[0].z + Pr[3].z) / 2),
                    new Mypoint((Pr[0].x + Pr[3].x) / 2, (Pr[0].y + Pr[3].y) / 2, Pr[3].z)
                ),new plot(
                   new Mypoint(Pr[1].x, Pr[1].y, (Pr[1].z + Pr[2].z) / 2),
                   new Mypoint((Pr[1].x + Pr[2].x) / 2, (Pr[1].y + Pr[2].y) / 2, Pr[1].z),
                   new Mypoint(Pr[2].x, Pr[2].y, (Pr[1].z + Pr[2].z) / 2),
                   new Mypoint((Pr[1].x + Pr[2].x) / 2, (Pr[1].y + Pr[2].y) / 2, Pr[2].z)
                )));
         
                }
                }

            string newpath = Path.ChangeExtension(path, "obj");
           // File.Create(newpath);
            foreach(var pair in V)
            {
                Load_cylinder( pair.Key, pair.Value);
            }
            File.WriteAllLines(newpath, file);
            return newpath;
        }
    }
}
