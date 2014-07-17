/* This source code was produced by mkbundle, do not edit */

#ifndef NULL
#define NULL (void *)0
#endif

typedef struct {
	const char *name;
	const unsigned char *data;
	const unsigned int size;
} MonoBundledAssembly;
void          mono_register_bundled_assemblies (const MonoBundledAssembly **assemblies);
void          register_config_for_assembly_func (const char* assembly_name, const char* config_xml);

extern const unsigned char assembly_data_TaskyAndroid_dll [];
static const MonoBundledAssembly assembly_bundle_TaskyAndroid_dll = {"TaskyAndroid.dll", assembly_data_TaskyAndroid_dll, 47104};
extern const unsigned char assembly_data_TaskyPortableLibrary_dll [];
static const MonoBundledAssembly assembly_bundle_TaskyPortableLibrary_dll = {"TaskyPortableLibrary.dll", assembly_data_TaskyPortableLibrary_dll, 10240};
extern const unsigned char assembly_data_Mono_Android_dll [];
static const MonoBundledAssembly assembly_bundle_Mono_Android_dll = {"Mono.Android.dll", assembly_data_Mono_Android_dll, 699904};
extern const unsigned char assembly_data_mscorlib_dll [];
static const MonoBundledAssembly assembly_bundle_mscorlib_dll = {"mscorlib.dll", assembly_data_mscorlib_dll, 1373696};
extern const unsigned char assembly_data_System_dll [];
static const MonoBundledAssembly assembly_bundle_System_dll = {"System.dll", assembly_data_System_dll, 269312};
extern const unsigned char assembly_data_Mono_Security_dll [];
static const MonoBundledAssembly assembly_bundle_Mono_Security_dll = {"Mono.Security.dll", assembly_data_Mono_Security_dll, 156672};
extern const unsigned char assembly_data_System_Core_dll [];
static const MonoBundledAssembly assembly_bundle_System_Core_dll = {"System.Core.dll", assembly_data_System_Core_dll, 126464};

static const MonoBundledAssembly *bundled [] = {
	&assembly_bundle_TaskyAndroid_dll,
	&assembly_bundle_TaskyPortableLibrary_dll,
	&assembly_bundle_Mono_Android_dll,
	&assembly_bundle_mscorlib_dll,
	&assembly_bundle_System_dll,
	&assembly_bundle_Mono_Security_dll,
	&assembly_bundle_System_Core_dll,
	NULL
};

static char *image_name = "TaskyAndroid.dll";

static void install_dll_config_files (void (register_config_for_assembly_func)(const char *, const char *)) {

}

static const char *config_dir = NULL;
void mono_mkbundle_init (void (register_bundled_assemblies_func)(const MonoBundledAssembly **), void (register_config_for_assembly_func)(const char *, const char *))
{
	install_dll_config_files (register_config_for_assembly_func);
	register_bundled_assemblies_func(bundled);
}
