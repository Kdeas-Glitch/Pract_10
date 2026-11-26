using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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


        public Computer addProc(string procces)
        {
            if (!string.IsNullOrEmpty(procces))
            {
                proc = procces;
                return this;
            }
            return this;
            
        }

        public Computer addRam(string ram)
        {
            if (!string.IsNullOrEmpty(ram))
            {
                vram = ram;
            }
            return this;
        }   

        public Computer addAcum(string ac)
        {
            if (!string.IsNullOrEmpty(ac))
            {
                accumulator = ac;
            }
            return this;
        }

        public Computer addVideo(string v)
        {
            if (!string.IsNullOrEmpty(v))
            {
                video = v;
            }
            return this;
        }

        public Computer? Build(Computer cp)
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

                    return this;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static Computer Clone(Computer cp)
        {
            int i = 0;

            while (File.Exists($"comp{i}.json"))
                i++;

            cp.id = i;

            return cp;
        }
    }
}
