using System;

namespace pclSGlocalizacion
{
	public static class SGLConstants
	{
		// Google Maps Keys
		public const string KEY_DIRECTIONS = "AIzaSyBD5yAqm8c8V4oFy-Z8aySQ8U4YHUA4Gv0";
		public const string KEY_ANDROID = "AIzaSyAMf478DgyDQO90jnDP9RZNDEKpXh3Elwg";
		public const string KEY_IOS = "AIzaSyBE4jKN577k8cuxYN2FI6-Ps3xkP82Td6Q";

		public const string URL_HOST = "http://162.243.146.161/es-MX/api/v1";

		public const string CELLIDENTIFIER = "TableCell";

		public const string ACTIVE_FINAL = "Activa Hasta";
		public const string ACTIVE_INIT = "Activa Desde";
		public const string ALERT = "Alerta";
		public const string ALIAS = "Alias";
		public const string CANCEL = "Cancelar";
		public const string CREATE = "Crear";
		public const string DEVICE = "Equipo";
		public const string DEVICE_ADD = "Add Device";
		public const string DEVICES = "Equipos";
		public const string DEVICES_2 = "Dispositivos";
		public const string DOWNLOADING = "Descanrgando";
		public const string EDIT = "Editar";
		public const string LOADING = "Cargando";
		public const string MENU = "Menú";
		public const string NAME = "Nombre";
		public const string NOTIFICATION = "Notificación";
		public const string NOTIFICATIONS = "Notificaciones";
		public const string RADIUS = "Radio";
		public const string SAVE = "Guardar";
		public const string SEARCH = "Búsqueda";
		public const string SHOW = "Mostrar";


		public const string ACCOUNT_DATE_FORMAT = "Formato de Fecha";
		public const string ACCOUNT_EMAIL_ALERT_ROUTE = "E-mails para alertas de rutas";
		public const string ACCOUNT_EMAIL_ALERT_ZONE = "E-mails para alertas de zona";
		public const string ACCOUNT_EMAIL_IGNITION = "E-mails para cambios de ignición";
		public const string ACCOUNT_EMAIL_SPEED = "E-mails para excesos de velocidad";
		public const string ACCOUNT_TEMPERATURE = "Temperatura";
		public const string ACCOUNT_TIME_ZONE = "Zona horaria";
		public const string ACCOUNT_UNIT = "Unidades";

		public const string MAP_SHAPE_EMAIL_ALERT_ROUTE = "E-mails para alertas de rutas";

		public const string MENU_ACCOUNT = "Mi cuenta";
		public const string MENU_CONCERN_POINTS = "Puntos de interés";
		public const string MENU_GROUPS = "Grupos";
		public const string MENU_LOG_OUT = "Cerrar Sesión";
		public const string MENU_MAP_SHAPES = "Geo Cercas";
		public const string MENU_REPORTS = "Reportes";
		public const string MENU_ROUTES = "Rutas";
		public const string MENU_SHOW = "Ver";
		public const string MENU_TOOLS = "Herramientas";
		public const string MENU_USERS = "Usuarios";

		public const string TITLE_ACCOUNT = "Mi Cuenta";
		public const string TITLE_ALERTS = "Alertas";
		public const string TITLE_CONCERN_POINTS = "Puntos de interés";
		public const string TITLE_CONFIGURATION = "Configuraciòn";
		public const string TITLE_DEVICES = "Unidades";
		public const string TITLE_GROUPS = "Grupos";
		public const string TITLE_MAP_SHAPES = "Geo Cercas";
		public const string TITLE_REPORTS = "Reportes";
		public const string TITLE_ROUTES = "Rutas";
		public const string TITLE_SHOW = "Ver";
		public const string TITLE_TOOLS = "Herramientas";
		public const string TITLE_USERS = "Usuarios";

		public const string REPORT_BINNACLE = "Bitácora";
		public const string REPORT_DEVICE = "Seleccione el equipo";
		public const string REPORT_DEVICES = "Seleccione los equipos";
		public const string REPORT_ENGINE_STATE = "Estado del motor";
		public const string REPORT_EVENTS = "Consolidado de Eventos";
		public const string REPORT_FINAL_DATE = "Día Final";
		public const string REPORT_FINAL_TIME = "Tiempo Final";
		public const string REPORT_GROUP = "Seleccione Grupo:";
		public const string REPORT_HISTORY = "Historial";
		public const string REPORT_INIT_DATE = "Día Inical";
		public const string REPORT_INIT_TIME = "Tiempo Inical";
		public const string REPORT_MAP_CLEAN = "Limpiar mapa";
		public const string REPORT_MAP_DEPLOY = "Desplegar en mapa";
		public const string REPORT_ODOMETER = "Odòmetro";
		public const string REPORT_ROUTE = "uta";
		public const string REPORT_SPEED = "Velocidad";
		public const string REPORT_STOPS = "Paradas";
		public const string REPORT_TEMPERATURE = "Temperatura";
		public const string REPORT_ZONES = "Zonas";

		public const string SHOW_CONCERN_POINTS = "Mostrar puntos de interés";
		public const string SHOW_DEVICES = "Mostrar equipos";
		public const string SHOW_LOCATIONS = "Mostrar ubicaciones";
		public const string SHOW_MAP_RESET = "Reestablecer mapa";
		public const string SHOW_REPORTS = "Mostrar reportes";
		public const string SHOW_ROUTES = "Mostrar rutas";
		public const string SHOW_ZONES = "Mostrar zonas";

		public const string TOOL_NEW_LOCATION = "Nueva Ubicación";
		public const string TOOL_NEW_ROUTE_SUGGESTED = "Nueva Ruta (Sugerida)";
		public const string TOOL_NEW_ROUTE_HISTORY = "Nueva Ruta (History)";
		public const string TOOL_NEW_ROUTE_POINT_POINT = "Nueva Ruta (Punto por Punto)";
		public const string TOOL_NEW_ZONE_CIRCULAR = "Nueva Zona (Circular)";
		public const string TOOL_NEW_ZONE_POLYGONAL = "Nueva Zona (Poligonal)";

		public const string USER_DEVICE = "Seleccione el equipo que desea agregar:";

		public const string LOGIN = "Autenticar";
		public const string LOGIN_FAILED = "Falla en autenticaciòn";
		public const string PASSWORD = "Contraseña";
		public const string USERNAME = "Nombre de usuario";
		public const string USER_ALLOWED_NO = "Usuario Deshabilitado";

		public const string MISSING_VALUES = "Campos vacios: ";

		public const string ALERT_ACTION_OK = "Aceptar";
		public const string ALERT_TITLE = "Alerta";

		public const string COLOR_ORANGE = "#d1833f";
		public const string COLOR_ORANGE_ES = "Naranja";
		public const string COLOR_BLUE = "#007aff";
		public const string COLOR_BLUE_ES = "Azul";
		public const string COLOR_GREEN = "#56d045";
		public const string COLOR_GREEN_ES = "Verde";

		// Report url
		public const string URL_REPORT_BINNACLE = "/reports/bitacora_report";
		public const string URL_REPORT_EVENTS = "/reports/consolidated_report";
		public const string URL_REPORT_HISTORY = "/reports/history_report";
		public const string URL_REPORT_ODOMETER = "/reports/odometer_report";
		public const string URL_REPORT_ROUTE = "/reports/route_report";
		public const string URL_REPORT_SPEED = "/reports/speeding_report";
		public const string URL_REPORT_STOPS = "/reports/stops_report";
		public const string URL_REPORT_TEMPERATURE = "/reports/temperature_report";
		public const string URL_REPORT_ZONE = "/reports/zone_report";
		public const string URL_REPORT_DRAW_ROUTE = "/reports/draw_route";

		public const string REST_PARAM_VALUES = "No pueden estar en blanco los siguientes campos: ";
		// Tools messages
		public const string MESSAGE_TOOLS_POLYGON = "¿Desea cerrar la cerca?";
		public const string MESSAGE_TOOLS_ZONE_FORM = "¿Mostrar a Sub Usuarios?";
		public const string MESSAGE_TOOLS_POLYLINE = "Descargando puntos";
	}
}

