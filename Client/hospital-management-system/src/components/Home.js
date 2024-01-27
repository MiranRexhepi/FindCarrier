import React, { useEffect } from 'react'
import { Link, useNavigate } from 'react-router-dom'

function Home() {

    const usenavigate = useNavigate();
    useEffect(() => {
        let username = sessionStorage.getItem('username');
        if (username === "" || username === null) {
            usenavigate('/login');
        }
    }, []);

    return (
        <div className='container'>
            <Link to={'/login'} className='btn btn-danger'>Logout</Link>
            <h3 className='text-center'>Welcome to Leart Istrefaj - Test page</h3>
        </div>
    )
}

export default Home