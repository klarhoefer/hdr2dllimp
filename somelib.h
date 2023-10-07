
struct State;
typedef struct State State;

typedef int int32_T;
typedef float real32_T;

State* sl_initialize();
void sl_terminate(State* handle);
void sl_set_some_value(State* handle, int32_T value);
void sl_process(State* handle, real32_T* samples);
