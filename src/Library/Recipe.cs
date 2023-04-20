//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public double GetProductionCost() // Para asignar esta responsabilidad se utiliza el Principio SRP, ya que esta se encarga únicamente de hacer los cálculos necesarios para obtener el costo total del producto final y no tiene responsabilidad sobre ningún otro tipo de información.
        {
            double total = 0;
            foreach (Step step in this.steps)
            {
                total += step.GetStepCost();
            }
            return total;
        }
        public void AddStep(Step step)
        {
            
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
    }
}