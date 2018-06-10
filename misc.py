import math


def fib(number):

    if number == 0:
        return 0
    if abs(number) == 1:
        return 1
    if number > 0:
        return fib(number - 1) + fib(number - 2)
    else:
        return fib(number + 2) - fib(number + 1)


def non_recursive_fib(number):

    if number == 0:
        return 0
    if abs(number) == 1:
        return 1

    if number > 0:

        res = 1
        fib1 = fib2 = 1
        i = 2

        while i < number:
            res = fib2 + fib1
            fib1 = fib2
            fib2 = res
            i += 1
        return res

    else:

        res = -1
        fib1 = 1
        fib2 = -1
        i = -2

        while i > number:

            res = fib1 - fib2
            fib1 = fib2
            fib2 = res
            i -= 1

        return res


def bubble_sort(array, order=1):

    # 1 - ascend, -1 - descend, else - default
    if order != 1:

        for i in range(0, len(array)):
            for j in range(i, len(array)):
                if array[i] < array[j]:
                    array[i], array[j] = array[j], array[i]

    else:

        for i in range(0, len(array)):
            for j in range(i, len(array)):
                if array[i] > array[j]:
                    array[i], array[j] = array[j], array[i]

    return array


def comb_sort(array):

    array_len = len(array)
    gap = (array_len * 10 // 13) if array_len > 1 else 0

    while gap:
        if 8 < gap < 11:
            gap = 11
        swapped = 0

        for i in range(array_len - gap):
            if array[i + gap] < array[i]:
                array[i], array[i + gap] = array[i + gap], array[i]
                swapped = 1
        gap = (gap * 10 // 13) or swapped

    return array


def insert_sort(array):

    for j in range(1, len(array)):

        key = array[j]
        i = j-1

        while (i >= 0) and (array[i] > key):
            array[i+1] = array[i]
            i = i-1
        array[i+1] = key

    return array


def merge(left, right):

    result = []

    while len(left) > 0 and len(right) > 0:

        if left[0] <= right[0]:
            result.append(left[0])
            left = left[1:]

        else:
            result.append(right[0])
            right = right[1:]

    if len(left):
        result.extend(left)
    if len(right):
        result.extend(right)

    return result


def merge_sort(array):

    left, right = [], []

    if len(array) <= 1:
        return array

    middle = len(array) // 2

    for item in array[0:middle]:
        left.append(item)

    for item in array[middle:len(array)]:
        right.append(item)

    left = merge_sort(left)
    right = merge_sort(right)
    result = merge(left, right)

    return result


def binary_search(array, item):

    if not array:
        return None

    lower_bound = 0
    upper_bound = len(array)

    while lower_bound != upper_bound:

        index = (lower_bound + upper_bound) // 2
        if array[index] == item:
            return index
        if array[index] > item:
            upper_bound = index
        else:
            lower_bound = index

    return None


def f(x):
    return x**2 + 3*x + 2


def trapeze(a, b, e=1.0):
    n = 1
    dx = (b - a) / n
    s = dx * (f(a) + 4 * f(a + dx / 2) + f(b)) / 6
    s1 = s + 2 * e  # make sure next cycle will run

    while abs(s - s1) > abs(e):

        n = n * 2
        s1 = s
        s = 0
        dx = (b - a) / n

        for i in range(0, n - 1):
            xa = a + dx * i
            xb = a + dx * (i+1)
            s = s + 0.5*dx * (f(xa) + f(xb))

    return s


def simpson(a, b, e=1.0):

    n = 1
    dx = (b-a)/n
    s = dx*(f(a) + 4*f(a+dx/2) + f(b))/6
    s1 = s + 2*e  # make sure next cycle will run

    while abs(s-s1) > abs(e):

        n = n*2
        s1 = s
        s = 0
        dx = (b-a)/n

        for i in range(0, n-1):

            xa = a + dx*i
            xb = xa + dx
            xab = xa + dx/2
            s = s + dx*(f(xa) + 4*f(xab) + f(xb))/6

    return s


def df(x, y):
    return x**2 - 2*y


def euler(a, b, ya, step_count):

    h = (b-a)/step_count
    y = ya

    for i in range(0, step_count):

        fx = df(a + i*h, y)
        y = y + fx*h

    return y


def modify_euler(a, b, ya, step_count):

    h = (b - a) / step_count
    y = ya

    for i in range(0, step_count):

        fx = df(a + i*h, y)
        fxx = df(a + (i+0.5)*h, y + 0.5*h*fx)
        y = y + fxx*h

    return y


def runge_kutta(a, b, ya, step_count):

    h = (b-a)/step_count
    y = ya

    for i in range(0, step_count):

        k1 = df(a + i*h, y)
        k2 = df(a + (i + 0.5) * h, y + k1 * h/2)
        k3 = df(a + (i + 0.5) * h, y + k2 * h / 2)
        k4 = df(a + (i + 1) * h, y + k3 * h)
        y = y + h/6 * (k1 + 2*k2 + 2*k3 + k4)

    return y


def main():

    print("fib(0): " + str(fib(0)))
    print("non_recursive_fib(20): " + str(non_recursive_fib(20)))
    print("bubble_sort([8, -3, 8]) # ascend: " + str(bubble_sort([8, -3, 8])))
    print("bubble_sort([8, -3, 8], -1) # descend: " + str(bubble_sort([8, -3, 8], -1)))
    print("comb_sort([8, -3, 8]): " + str(comb_sort([8, -3, 8])))
    print("insert_sort([7, 7, 7, -8, 6]): " + str(insert_sort([7, 7, 7, -8, 6])))
    print("merge_sort([7, 7, 7, -8, 6]): " + str(merge_sort([7, 7, 7, -8, 6])))
    print("binary_search([-5, -4, -3, 3, 4, 5], -4): " + str(binary_search([-5, -4, -3, 3, 4, 5], -4)))
    print("trapeze(7, 8, 0.1) (f(x) = x**2 + 3*x + 2): " + str(trapeze(7, 8, 0.1)))
    print("simpson(7, 8, 0.1) (f(x) = x**2 + 3*x + 2): " + str(simpson(7, 8, 0.1)))
    print("euler(-5, 5, 0, 50): " + str(euler(-5, 5, 0, 50)))
    print("modify_euler(-5, 5, 0, 50): " + str(modify_euler(-5, 5, 0, 50)))
    print("runge_kutta(-5, 5, 0, 50): " + str(runge_kutta(-5, 5, 0, 50)))


if __name__ == "__main__":
    main()
