void fillArrayRandInt(int arr[], int size);
void printArrayInt(int arr[], int size);
int minInArrayInt(int arr[], int size);
int maxInArrayInt(int arr[], int size);
void quickSortInt(int arr[], int size);

void fillArrayRandDouble(double arr[], int size);
void printArrayDouble(double arr[], int size);
int minInArrayDouble(double arr[], int size);
int maxInArrayDouble(double arr[], int size);
void quickSortDouble(double arr[], int size);

void fillArrayRandChar(char arr[], int size);
void printArrayChar(char arr[], int size);
int minInArrayChar(char arr[], int size);
int maxInArrayChar(char arr[], int size);
void quickSortChar(char arr[], int size);

#ifdef INTEGER
    #define fillArrayRand fillArrayRandInt
    #define printArray printArrayInt
    #define minInArray minInArrayInt
    #define maxInArray maxInArrayInt
    #define quickSort quickSortInt
#endif
#ifdef DOUBLE
    #define fillArrayRand fillArrayRandDouble
    #define printArray printArrayDouble
    #define minInArray minInArrayDouble
    #define maxInArray maxInArrayDouble
    #define quickSort quickSortDouble
#endif
#ifdef CHAR
    #define fillArrayRand fillArrayRandChar
    #define printArray printArrayChar
    #define minInArray minInArrayChar
    #define maxInArray maxInArrayChar
    #define quickSort quickSortChar
#endif