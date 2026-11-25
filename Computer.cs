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
        
        
        public string Proc { get
            {
                return proc;
            } }

        public string Vram
        {
            get
            {
                return vram;
            }
        }
        public string Accumulator
        {
            get
            {
                return accumulator;
            }
        }
        public string Video
        {
            get
            {
                return video;
            }
        }

        List<Computer> list = new();


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

        public bool Build()
        {
            if (proc != null && vram != null && accumulator != null && video != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clone(Computer cp)
        {
            string jsonString = JsonSerializer.Serialize(cp);
            int i = 0;

            while (File.Exists($"comp{i}.json"))
                i++;

            string fileName = $"comp{i}.json";
            File.WriteAllText(fileName, jsonString);
        }
    }
}
