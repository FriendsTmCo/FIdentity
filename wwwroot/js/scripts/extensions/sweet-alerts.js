$(function () {
    $(document).on('click', '.delete-confirm', function (event) {
        event.preventDefault();
        const url = $(this).attr('href');
        Swal.fire({
            title: 'آیا مطمئنید؟',
            text: "این عمل قابل بازگشت نخواهد بود!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonText: 'تایید',
            confirmButtonClass: 'btn btn-primary',
            cancelButtonClass: 'btn btn-danger ml-1',
            cancelButtonText: 'انصراف',
            buttonsStyling: false,
        }).then(function (result) {
            if (result.value)
                window.location.href = url;
            else
                return false;
        });
    });
});
