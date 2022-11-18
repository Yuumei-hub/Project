def fibo(n):
    a=[0,1]
    for i in range(1,n-1):
        temp=a[i]+a[i-1]
        a.append(temp)
        i+=1
    return a
print(fibo(4))
#0,1,1,2,3,5#

li=[0,1,2,3,4,5,6,7,8,9,10,11,12]
li2=list(map(fibo,li))
print(li2)


li3=[fibo(x) for x in range(12 if x%2==0)]
print (li3)


def isOdd(x):
    return x%2== True
print("------")
print(li2)
li4=list(filter(isOdd,li2))
print("-------")
print(li4)