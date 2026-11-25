using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pract10
{
    public class Computer
    {

        private string? proc = null;
        private string? vram = null;
        private string? accumulator = null;
        private string? video = null;
        public int id = -1;
        
        
        public string Proc { 
            get
            {
                return proc;
            }
            set
            {
                proc = value;
            }
        }

        public string Vram
        {
            get
            {
                return vram;
            }
            set
            {
                vram = value;
            }
        }
        public string Accumulator
        {
            get
            {
                return accumulator;
            }
            set
            {
                accumulator = value;
            }
        }
        public string Video
        {
            get
            {
                return video;
            }
            set
            {
                video = value;
            }
        }


        public void addProc(string procces)
        {
            if (!string.IsNullOrEmpty(procces))
            {
                proc = procces;
            }
        }

        public void addRam(string ram)
        {
            if (!string.IsNullOrEmpty(ram))
            {
                vram = ram;
            }
        }

        public void addAcum(string ac)
        {
            if (!string.IsNullOrEmpty(ac))
            {
                accumulator = ac;
            }
        }

        public void addVideo(string v)
        {
            if (!string.IsNullOrEmpty(v))
            {
                video = v;
            }
        }

        public bool Build(Computer cp)
        {
            try
            {
                if (proc != null && vram != null && accumulator != null && video != null)
                {
                    
                    int i = 0;
                    if (cp.id == -1)
                    {
                        while (File.Exists($"comp{i}.json"))
                        {
                            i++;
                        }
                    }
                    else
                        i = cp.id;

                    string filename = $"comp{i}.json";
                    string json = JsonSerializer.Serialize(cp);
                    File.WriteAllText(filename, json);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void Clone(Computer cp)
        {
            
            int i = 0;

            while (File.Exists($"comp{i}.json"))
                i++;

            cp.id = i;

            string jsonString = JsonSerializer.Serialize(cp);
            string fileName = $"comp{i}.json";
            File.WriteAllText(fileName, jsonString);
        }
    }
}
