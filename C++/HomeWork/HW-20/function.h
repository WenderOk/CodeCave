void fillArrayRandInt(int arr[], int size);
void printArrayInt(int arr[], int size);
int minInArrayInt(int arr[], int size);
int maxInArrayInt(int arr[], int size);
void quickSortInt(int arr[], int size);
void changeArrayInt(int arr[], int size, int index, int value);

void fillArrayRandDouble(double arr[], int size);
void printArrayDouble(double arr[], int size);
int minInArrayDouble(double arr[], int size);
int maxInArrayDouble(double arr[], int size);
void quickSortDouble(double arr[], int size);
void changeArrayDouble(double arr[], int size, int index, double value);

void fillArrayRandChar(char arr[], int size);
void printArrayChar(char arr[], int size);
int minInArrayChar(char arr[], int size);
int maxInArrayChar(char arr[], int size);
void quickSortChar(char arr[], int size);
void changeArrayChar(char arr[], int size, int index, char value);


#ifdef INTEGER
    #define fillArrayRand fillArrayRandInt
    #define printArray printArrayInt
    #define minInArray minInArrayInt
    #define maxInArray maxInArrayInt
    #define quickSort quickSortInt
    #define changeArray changeArrayInt
#endif
#ifdef DOUBLE
    #define fillArrayRand fillArrayRandDouble
    #define printArray printArrayDouble
    #define minInArray minInArrayDouble
    #define maxInArray maxInArrayDouble
    #define quickSort quickSortDouble
    #define changeArray changeArrayDouble
#endif
#ifdef CHAR
    #define fillArrayRand fillArrayRandChar
    #define printArray printArrayChar
    #define minInArray minInArrayChar
    #define maxInArray maxInArrayChar
    #define quickSort quickSortChar
    #define changeArray changeArrayChar
#endif