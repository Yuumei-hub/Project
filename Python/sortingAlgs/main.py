import random
from timeit import default_timer as timer

def bubble_sort(list,order):

        if order=="descending": #descending
            n = len(list)
            swapped = False
            for i in range(n - 1):
                for j in range(0, n - i - 1):
                    if list[j] < list[j + 1]:
                        swapped = True
                        list[j], list[j + 1] = list[j + 1], list[j]
                if not swapped:
                    return

        if order=="ascending": #ascending
            n = len(list)
            swapped = False
            for i in range(n - 1):
                for j in range(0, n - i - 1):
                    if list[j] > list[j + 1]:
                        swapped = True
                        list[j], list[j + 1] = list[j + 1], list[j]
                if not swapped:
                    return

def selection_sort(list, order):

    size=len(list)

    if order=="ascending":
        for ind in range(size):
            min_index = ind

            for j in range(ind + 1, size):
                if list[j] < list[min_index]:
                    min_index = j
            (list[ind], list[min_index]) = (list[min_index], list[ind])
        return 0

    if order=="descending":
        for ind in range(size):
            max_index = ind
            for j in range(ind + 1, size):
                if list[j] > list[max_index]:
                    max_index = j
            (list[ind], list[max_index]) = (list[max_index], list[ind])
        return 0

def insertion_sort(list, order):
    if order=="ascending":
        if (n := len(list)) <= 1:
            return
        for i in range(1, n):
            key = list[i]
            j = i - 1
            while j >= 0 and key < list[j]:
                list[j + 1] = list[j]
                j -= 1
            list[j + 1] = key
    if order=="descending":
        if (n := len(list)) <= 1:
            return
        for i in range(1, n):
            key = list[i]
            j = i - 1
            while j >= 0 and key > list[j]:
                list[j + 1] = list[j]
                j -= 1
            list[j + 1] = key

if __name__ == '__main__':
    randomlist1 = random.sample(range(0, 10000), 10000)

    order=input("ascending or descending? ")
    start=timer()
    bubble_sort(randomlist1,order)
    end=timer()

    print("Execution time for bubble sort: "+ str(end-start)+" seconds")

    randomlist2 = random.sample(range(0, 10000), 10000)
    start=timer()
    selection_sort(randomlist2,order)
    end=timer()
    print("Execution time for selection sort: "+ str(end-start)+" seconds")

    randomlist3 = random.sample(range(0, 10000), 10000)
    start=timer()
    insertion_sort(randomlist3,order)
    end=timer()
    print("Execution time for insertion sort: "+ str(end-start) +" seconds")
