﻿using DoctorAppoinmentModelLibery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppoinmentBLLibery
{
    public interface IDoctorService
    {
        Doctor AddDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        Doctor UpdateDoctor(Doctor doctor);
        bool DeleteDoctor(int id);
        List<Doctor> GetAllDoctors();
        List<Doctor> SearchDoctors(string keyword);
    }
}
