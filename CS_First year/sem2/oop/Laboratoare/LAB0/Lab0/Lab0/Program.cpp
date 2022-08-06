#define _CRT_SECURE_NO_DEPRECATE
#include <stdio.h>

int main()
{
	int n , i , nr , sum = 0;
	printf("%s", "Introduceti n : ");
	scanf("%d", &n);

		for (i = 0; i < n; ++i)
		{
			nr = 0;
			if (i == 0) {
				printf("%s", "Introduceti primul numar : ");
			}
			else {
				printf("Introduceti al %d-lea numar : ", i+1);
			}
			scanf("%d", &nr);
			sum = sum + nr;
		}
		printf("%d", sum);
	return 0;	
}