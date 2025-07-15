import sys

ALLOWED_NAMES = {
    'abs': abs,
    'round': round,
}

def safe_eval(expr):
    """Evaluate a math expression safely."""
    try:
        # restrict builtins
        result = eval(expr, {"__builtins__": None}, ALLOWED_NAMES)
    except Exception as e:
        raise ValueError(str(e))
    return result


def main():
    if len(sys.argv) > 1:
        expr = " ".join(sys.argv[1:])
        try:
            print(safe_eval(expr))
        except Exception as e:
            print(f"Error: {e}")
        return

    print("Simple Calculator. Type 'quit' to exit.")
    while True:
        expr = input('> ')
        if expr.lower() in ('quit', 'exit'):
            break
        if not expr.strip():
            continue
        try:
            result = safe_eval(expr)
            print(result)
        except Exception as e:
            print(f"Error: {e}")


if __name__ == '__main__':
    main()
