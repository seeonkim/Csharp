using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

namespace OOP.Infra {
    public class Database {
        public string rootDir() {
            return "";
        }
        public void Read (string fileName) {
            string[] content;
            string filepath = this.rootDir();
            using (StreamReader reader = new StreamReader(filepath)) { 
                string line = reader.ReadLine();
            }
        }
        public void Write(string fileName, string row) {
            string filepath = this.rootDir();
            using (StreamWriter writer = new StreamWriter(filepath, true)) { 
                writer.WriteLine("row"); 
                writer.Close();
            }

        }

        public void Add() {
            
        }

        public void Update() {
            
        }
    }
}