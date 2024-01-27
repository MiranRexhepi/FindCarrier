import React from 'react';
import { Link } from 'react-router-dom';
import error404 from '../error404.png';
// import error404 from '../404.png';

export default function Error() {
    return (
        <div className='error'>
            <img src={error404} className='error-img' alt='photo' />
            <h2 className='title-error'>Oops! Page Not Found  </h2>
            <div className='buttons'>
                <Link className='btn-logout err ms-4 mt-4' to='/login'>Home</Link>
                <Link className='btn-logout err ms-4 mt-4' to='/report'>Report</Link>
            </div>
        </div>
    )
}
