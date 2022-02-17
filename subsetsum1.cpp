#include<bits/stdc++.h>
using namespace std;
bool issubset(int a[], int n, int sum){

    if(sum==0){
        return true;
    }
    if(sum!=0&& n==0){
        return false;

    }
     if(a[n-1]>sum){

        issubset(a, n-1,sum);
    }
    return issubset(a, n-1, sum)||issubset(a, n-1, sum-a[n-1]);




}
int main(){
    int a[] = {1,2,3};
    int n =3;
    int sum =5;
    if(issubset(a,n, sum)==true){
            cout<<"there exit subset"<<endl;



    }





}
