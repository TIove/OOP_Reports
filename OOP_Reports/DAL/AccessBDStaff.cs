using System;
using System.Collections.Generic;
using OOP_Reports.DataBases;
using OOP_Reports.Entities;

namespace OOP_Reports.DAL {
    public class AccessBDStaff {
        public void Add() {
            
        }

        public void Remove()
        {
            
        }

        public Employee Get(Guid id)
        {
            return BDStaff.ListOfStaff.GetValueOrDefault(id, null);
        }
    }
}