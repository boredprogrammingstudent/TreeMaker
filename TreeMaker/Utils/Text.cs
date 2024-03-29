﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raylib_cs.Raylib;
using Raylib_cs;
using System.Numerics;
using static TreeMaker.Settings.UserSettings;
using TreeMaker.Settings;
using Color = Raylib_cs.Color;
namespace TreeMaker.Utils
{
    static class Text
    {
        static readonly Color color = Colors[(int)ColorTypes.Text];
        public static void Write(string text, int posX, int posY, int textSize)
        {
            DrawTextEx(FONT, text, new(posX, posY), textSize, 5, color);
        }
        public static void WriteCentered(string text, Vector2 topLeft, Vector2 bottomRight, int textSize)
        {
            WriteCentered(text, textSize, topLeft, bottomRight - topLeft);
        }
        public static void WriteCentered(string text, int textSize, Vector2 spacePos, Vector2 spaceSize)
        {
            int posX = GetPosX(spacePos.X, spaceSize.X, text, textSize);
            int posY = GetPosY(spacePos.Y, spaceSize.Y, textSize);
            Write(text, posX, posY, textSize);
        }
        public static int GetPosX(float spaceX, float spaceWidth, string text, int textSize)
        {
            return (int)(spaceX - MeasureTextEx(FONT,text, textSize, 5).X / 2f + spaceWidth / 2f);
        }
        public static int GetPosY(float spaceY, float spaceHeight, float textSize)
        {
            return (int)(spaceY + spaceHeight / 2f - textSize / 2f);
        }
        public static string Unknown => Language switch
        {
            Languages.French => "Inconnu",
            _ => "Unknown"
        };
        public static string FindPerson => Language switch
        {
            Languages.French => "Trouver une personne",
            _ => "Find Person"
        };
        public static string AddPerson => Language switch
        {
            Languages.French => "Ajouter une Personne",
            _ => "Add Person"
        };
        public static string CreateTree => Language switch
        {
            Languages.French => "Créer l'arbre",
            _ => "Create Tree"
        };
        public static string NameTree => Language switch
        {
            Languages.French => "Nommez cet arbre",
            _ => "Name this tree"
        };
        public static string NewTree => Language switch
        {
            Languages.French => "Créer un Arbre",
            _ => "New Tree"
        };
        public static string LoadTree => Language switch
        {
            Languages.French => "Ouvrir un Arbre",
            _ => "Load Tree"
        };
        public static string Parents => Language switch
        {
            _ => "Parents"
        };
        public static string Children => Language switch
        {
            Languages.French => "Enfants",
            _ => "Children"
        };
        public static string Friends => Language switch
        {
            Languages.French => "Amis",
            _ => "Friends"
        };
        public static string SpouseOrLovers => Language switch
        {
            Languages.French => "Époux(ses) ou Amoureux(ses)",
            _ => "Spouse or Lovers"
        };
        public static string Other => Language switch
        {
            Languages.French => "Autre",
            _ => "Other"
        };
        public static string FirstName => Language switch
        {
            Languages.French => "Prénom",
            _ => "First Name"
        };
        public static string LastName => Language switch
        {
            Languages.French => "Nom de famille",
            _ => "Last Name"
        };
        public static string DayOfBirth => Language switch
        {
            Languages.French => "Date de naissance",
            _ => "Day of Birth"
        };
        public static string MonthOfBirth => Language switch
        {
            Languages.French => "Mois de naissance",
            _ => "Month of Birth"
        };
        public static string YearOfBirth => Language switch
        {
            Languages.French => "Année de naissance",
            _ => "Year of Birth"
        };        public static string DayOfDeath => Language switch
        {
            Languages.French => "Date de décès",
            _ => "Day of Death"
        };
        public static string MonthOfDeath => Language switch
        {
            Languages.French => "Mois de décès",
            _ => "Month of Death"
        };
        public static string YearOfDeath => Language switch
        {
            Languages.French => "Année de décès",
            _ => "Year of Death"
        };
        public static string Save => Language switch
        {
            Languages.French => "Sauvegarder",
            _ => "Save"
        };
        public static string ThisPersonCouldNotBeFound => Language switch
        {
            Languages.French => "Cette personne ne peut être trouvée",
            _ => "This Person Could Not Be Found"
        };
        public static string DoYouWannaSave => Language switch
        {
            Languages.French => "Tout changemant non sauvegardé sera détruit",
            _ => "All unsave changes will disappear"
        };
        public static string Cancel => Language switch
        {
            _ => "Cancel"
        };
        public static string DontSave => Language switch
        {
            Languages.French => "Ne pas sauvegarder",
            _ => "Dont save"
        };
        public static string ThereWasAProblem => Language switch
        {
            Languages.French => "Il y eu un problème",
            _ => "There was a problem"
        };
        public static string Settings => Language switch
        {
            Languages.French => "Réglage",
            _ => "Settings"
        };
        public static string Edit => Language switch
        {
            Languages.French => "Modifier",
            _ => "Edit"
        };
        public static string ViewMoreImages => Language switch
        {
            Languages.French => "Voir plus d'images",
            _ => "View More Images"
        };
        public static string AddImage => Language switch
        {
            Languages.French => "Ajouter une image",
            _ => "Add Image"
        };
        public static string AddRelationship => Language switch
        {
            Languages.French => "Ajouter une relation",
            _ => "Add Relationship"
        };
        public static string ChooseRelationship => Language switch
        {
            Languages.French => "Choisir le type de relation",
            _ => "Choose relationship type"
        };
        public static string ParentExample => Language switch
        {
            Languages.French => $"Par example : si vous ajoutez un père,\nchoisissez l'option {Relationship(Relationships.Parents)}",
            _ => $"For example : if you're adding a father,\nchoose the option {Relationship(Relationships.Parents)}"
        };
        public static string Yes => Language switch
        {
            Languages.French => "Oui",
            _ => "Yes"
        };
        public static string No => Language switch
        {
            Languages.French => "Non",
            _ => "No"
        };
        public static string DoYouWantToAnInverseRelationship => Language switch
        {
            Languages.French => "Voulez-vous ajouter une relation inverse ?",
            _ => "Do you want to add an inverse relationship ?"
        };
        public static string[] GetAllRelationships(bool addOther)
        {
            string[] strings = new string[(int)(addOther ? Relationships.Other + 1 : Relationships.Other)];
            for(int i = 0; i < strings.Length; ++i)
            {
                strings[i] = Relationship((Relationships)i);
            }
            return strings;
        }
        public static string Relationship(Relationships rel) => rel switch
        {
            Relationships.Parents => Parents,
            Relationships.Children => Children,
            Relationships.Friends => Friends,
            Relationships.Spouse_or_Lover => SpouseOrLovers,
            _ => Other
        };
    }
}
