//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainC.Globalization {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MovimientoStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MovimientoStrings() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DomainC.Globalization.MovimientoStrings", typeof(MovimientoStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Cupo diario Excedido.
        /// </summary>
        public static string ErrorLimiteDiarioDebito {
            get {
                return ResourceManager.GetString("ErrorLimiteDiarioDebito", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Saldo No Disponible.
        /// </summary>
        public static string ErrorSaldoNoDisponible {
            get {
                return ResourceManager.GetString("ErrorSaldoNoDisponible", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor del Movimiento debe ser mayor a 0.
        /// </summary>
        public static string ErrorValorCreditoNegativo {
            get {
                return ResourceManager.GetString("ErrorValorCreditoNegativo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a El valor del Movimiento debe ser menor a 0.
        /// </summary>
        public static string ErrorValorDebitoPositivo {
            get {
                return ResourceManager.GetString("ErrorValorDebitoPositivo", resourceCulture);
            }
        }
    }
}
